using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementTesting
{
    public static class Helper
    {
        /// <summary>
        /// Check if given Function throws an exception and is equal with an expected exception
        /// </summary>
        /// <param name="_action">Function to check</param>
        /// <param name="_expected">Expected Exception</param>
        /// <param name="_actually">Actuall thrown Exception (null when no exception was thrown)</param>
        /// <returns>true: Function called an Exception and is equal with expected Exception | 
        /// false: Function did not call an exception or is not equal with expected Exception</returns>
        public static bool ThrowException(Action _action, Exception _expected, out Exception _actually)
        {
            bool toReturn = false;
            _actually = null;

            try
            {
                Task t = new Task(_action);
                t.Start();
                t.Wait();
            }
            catch (Exception e)
            {
                Type e1 = e.InnerException.GetType();
                Type e2 = _expected.GetType();
                if (e1 == e2) toReturn = true;
                _actually = e.InnerException;
            }

            return toReturn;
        }

        /// <summary>
        /// Check if given Function throws an exception
        /// </summary>
        /// <param name="_action">Function to check</param>
        /// <param name="_actually">Actuall thrown Exception (null when no exception was thrown)</param>
        /// <returns>true: Function called an Exception | false: Function did not call an exception</returns>
        public static bool ThrowException(Action _action, out Exception _actually)
        {
            _actually = null;

            try
            {
                Task t = new Task(_action);
                t.Start();
                t.Wait();
            }
            catch (Exception e)
            {
                _actually = e.InnerException;
            }

            return _actually == null ? false : true;

        }


    }
}
