namespace WebApiHandlerFlow.Domain
{
    public class HandlerData
    {
        private string _someStandardData;
        public string SomeStandardData
        {
            get
            {
                if (_someStandardData == null)
                    LoadSomeStandardData();

                return _someStandardData;
            }
            set
            {
                _someStandardData = value;
            }
        }

        private void LoadSomeStandardData()
        {
            _someStandardData = ":)";
        }
    }
}
