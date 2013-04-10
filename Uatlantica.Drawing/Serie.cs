
namespace Uatlantica.Drawing
{
    public class Serie
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Serie" /> class.
        /// </summary>
        public Serie()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Serie" /> class.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Value">The value.</param>
        public Serie(string Name, int Value)
            : this()
        {
            this.Name = Name;
            this.Value = Value;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value
        {
            get;
            set;
        }
    }
}
