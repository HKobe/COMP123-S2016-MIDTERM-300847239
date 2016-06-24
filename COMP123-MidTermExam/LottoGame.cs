using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP123_MidTermExam
{
    /**
     * <summary>
     * This abstract class is a blueprint for all Lotto Games
     * </summary>
     * 
     * @class LottoGame
     * @property {int} ElementNum;
     * @property {int} SetSize;
     */
    public abstract class LottoGame
    {
        #region Private Instance Variables
        // PRIVATE INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // CREATE private fields here --------------------------------------------
        private int _elementNumber;
        private int _setSize;
        private Random _random;
        private List<int> _elementList = new List<int>();
        private List<int> _numberList = new List<int>();
        #endregion

        #region Public Properties
        // PUBLIC PROPERTIES ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        // CREATE public properties here -----------------------------------------
        public int ElementNumber
        {
            get
            {
                return this._elementNumber;
            }
            set
            {
                this._elementNumber = value;
            }
        }

        public List<int> ElementList
        {
            get
            {
                return this._elementList;
            }
        }

        public List<int> NumberList
        {
            get
            {
                return this._numberList;
            }

        }

        public Random random
        {
            get
            {
                return this._random;
            }
        }

        public int SetSize
        {
            get
            {
                return this._setSize;
             }

            set
            {
                this._setSize = value;
            }
        }
        #endregion

        #region Constructors
        // CONSTRUCTORS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /**
         * <summary>
         * This constructor takes two parameters: elementNumber and setSize
         * The elementNumber parameter has a default value of 6
         * The setSize parameter has a default value of 49
         * </summary>
         * 
         * @constructor LottoGame
         * @param {int} elementNumber
         * @param {int} setSize
         */
        public LottoGame(int elementNumber = 6, int setSize = 49)
        {
            // assign elementNumber local variable to the ElementNumber property
            this.ElementNumber = elementNumber;

            // assign setSize local variable tot he SetSize property
            this.SetSize = setSize;

            // call the _initialize method
            this._initialize();

            // call the _build method
            this._build();
        }
        #endregion

        #region Private Methods
        // PRIVATE METHODS ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        // CREATE the private _initialize method here -----------------------------
        //instantiates new objects for the private fields listed below
        private void _initialize()
        {
            //new Objects
            List<int> numberList = new List<int>();
            List<int> elementList = new List<int>();
            Random random = new Random();

            _numberList = numberList;
            this._elementList = elementList;
            this._random = random;

        }
        // CREATE the private _build method here -----------------------------------
        private void _build()
        {
            //Loopto ADD interger Literals from 1 - SetSize
            for (int i = 1; i < SetSize+1; i++)
            {
                NumberList.Add(i);
            }
        }
        #endregion

        #region Overriden Methods
        // OVERRIDEN METHODS ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /**
         * <summary>
         * Override the default ToString function so that it displays the current
         * ElementList
         * </summary>
         * 
         * @override
         * @method ToString
         * @returns {string}
         */
        public override string ToString()
        {
            // create a string variable named lottoNumberString and intialize it with the empty string
            string lottoNumberString = String.Empty;

            // for each lottoNumber in ElementList, loop...
            foreach (int lottoNumber in ElementList)
            {
                // add lottoNumber and appropriate spaces to the lottoNumberString variable
                lottoNumberString += lottoNumber > 9 ? (lottoNumber + " ") : (lottoNumber + "  ");
            }

            return lottoNumberString;
        }

        #endregion

        #region PickElements

        // PUBLIC METHODS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        // CREATE the public PickElements method here ----------------------------
        //Randomly Selects and Removes numbers from the NumberList and Adds to the ElementList

        public void PickElements()
        {
            if (ElementList.Count > 0)
            {
                ///Clears
                ElementList.Clear();
                NumberList.Clear();
                //rebuild using _build method
                this._build();
            }
            ///local variable for random
            int randomIndex = this.random.Next(SetSize);            
            //REMOVE
            NumberList.RemoveAt(randomIndex);
            //ADDS
            ElementList.Add(randomIndex);
            //Sorts
            ElementList.Sort();


        }

        #endregion
    }
}
