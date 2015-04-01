
namespace Utilities.DesignPattern
{
    public class Singleton<T> where T:class,new()
    {
        public static T Instance
        {
            get { return SingletionCreator<T>.CreatorInstance; }
        }

        /// <summary>
        /// Protected constructor to avoid class instance creation
        /// </summary>
        protected Singleton() { }

        private sealed class SingletionCreator<S> where S : class, new()
        {
            private static readonly S _instance = new S();

            public static S CreatorInstance
            {
                get { return _instance; }
            }
        }
    }
}
