using System;
using System.Collections.Generic;
using System.Globalization;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Views;
using Android.Widget;
using SbsMobile.SharedPcl;

namespace SbsMobile.Droid.Fragments
{
    public class TipoCambioFragment : ListFragment, DatePickerDialog.IOnDateSetListener
    {
        private List<TipoCambio> _listaTipoCambio;

        async void GetTipoCambio()
        {
            var client = new TipoCambioClient();
            _listaTipoCambio = await client.GetTipoCambio(new TipoCambio { Fecha = _queryDate });
            //var listaNombresTest = new List<string>();
            //_listaTipoCambio.ForEach(t => listaNombresTest.Add(t.Moneda.Descripcion));
            //ListAdapter = new ArrayAdapter<String>(View.Context, Resource.Layout.SimpleListItem, listaNombresTest);
            var adapter = ListAdapter as TipoCambioListViewAdapter;
            if (adapter != null)
            {
                adapter.ListaTipoCambio = _listaTipoCambio;
                adapter.NotifyDataSetChanged();
            }
        }

        private DateTime _queryDate;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RetainInstance = true;
            SetHasOptionsMenu(true);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.TipoCambio, container, false);
            _queryDate = new DateTime(2010, 12, 01);
            return view;
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            SetTextFecha();
            if (ListAdapter == null)
            {
                ListAdapter = new TipoCambioListViewAdapter(view.Context);
                GetTipoCambio();
            }
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            inflater.Inflate(Resource.Menu.tipocambio, menu);
            base.OnCreateOptionsMenu(menu, inflater);
            var tf = Typeface.CreateFromAsset(Application.Context.Assets, "fontawesome-webfont.ttf");
            var actionView = menu.FindItem(Resource.Id.menu_tc_calendar).ActionView;
            if (actionView != null)
            {
                var btn = actionView.FindViewById<Button>(Resource.Id.btnMenuCalendar);
                btn.SetTypeface(tf, TypefaceStyle.Normal);
                btn.Click += (sender, args) =>
                {
                    var dialog = new DatePickerDialogFragment(Activity, _queryDate, this);
                    dialog.Show(FragmentManager, null);
                };
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_tc_calendar:
                    var dialog = new DatePickerDialogFragment(Activity, _queryDate, this);
                    dialog.Show(FragmentManager, null);
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public void OnDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth)
        {
            var date = new DateTime(year, monthOfYear + 1, dayOfMonth);
            _queryDate = date;
            SetTextFecha();

            GetTipoCambio();
        }

        private void SetTextFecha()
        {
            View.FindViewById<TextView>(Resource.Id.dateDisplay).Text = string.Format("Para el día {0}",
                _queryDate.ToString("D", CultureInfo.CreateSpecificCulture("es-PE")));
        }

        class TipoCambioListViewAdapter : BaseAdapter
        {
            readonly Context _context;

            private IReadOnlyList<TipoCambio> _listaTipoCambio;

            public IReadOnlyList<TipoCambio> ListaTipoCambio
            {
                set
                {
                    _listaTipoCambio = value;
                }
            }

            public override int Count
            {
                get { return _listaTipoCambio == null ? 0 : _listaTipoCambio.Count; }
            }

            public override Java.Lang.Object GetItem(int position)
            {
                return new Java.Lang.String(_listaTipoCambio[position].ToString());
            }

            public TipoCambioListViewAdapter(Context context)
            {
                _context = context;
            }

            public override long GetItemId(int position)
            {
                return _listaTipoCambio[position].GetHashCode();
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                if (convertView == null)
                {
                    var inflater = LayoutInflater.FromContext(_context);
                    convertView = inflater.Inflate(Resource.Layout.SimpleListItem, parent, false);
                    convertView.Id = 0x60000000;
                }
                convertView.Id++;
                var txtMoneda = convertView.FindViewById<TextView>(Resource.Id.txtMoneda);
                var txtCompra = convertView.FindViewById<TextView>(Resource.Id.txtCompra);
                var txtVenta = convertView.FindViewById<TextView>(Resource.Id.txtVenta);

                var tipoCambio = _listaTipoCambio[position];
                txtMoneda.Text = tipoCambio.Moneda.Descripcion;
                txtCompra.Text = tipoCambio.Compra;
                txtVenta.Text = tipoCambio.Venta;

                return convertView;
            }
        }
    }
}