using Android.App;
using Android.Widget;
using Android.OS;

namespace spinner_task
{
	[Activity(Label = "spinner_task", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		Spinner spinner;
		RadioGroup radioGroup;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			spinner = FindViewById<Spinner>(Resource.Id.spinner);
			radioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);

			var toggleButton = FindViewById<ToggleButton>(Resource.Id.toggleButton1);
			var layout = FindViewById<LinearLayout>(Resource.Id.linearLayout1);

			toggleButton.CheckedChange += delegate
			{
				if (toggleButton.Checked)
					layout.Visibility = Android.Views.ViewStates.Visible;
				else
					layout.Visibility = Android.Views.ViewStates.Gone;
			};

			ChangeList();
			radioGroup.CheckedChange += delegate
			{
				ChangeList();
			};
		}

		void ChangeList()
		{
			var checkedID = radioGroup.CheckedRadioButtonId;
			ArrayAdapter adapter;

			if (checkedID == Resource.Id.radioButtonItalian)
			{
				adapter = ArrayAdapter.CreateFromResource(
					this,
					Resource.Array.italian,
					Android.Resource.Layout.SimpleSpinnerItem
				);
			}
			else
			{
				adapter = ArrayAdapter.CreateFromResource(
					this,
					Resource.Array.french,
					Android.Resource.Layout.SimpleSpinnerItem
				);
			}

			adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner.Adapter = adapter;
		}
	}
}

