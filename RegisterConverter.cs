using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TessyRegisterConverter
{
    class RegisterConverter
    {
        #region "Private Members"

        string m_variableHeader;
        List<string> m_types;
        int m_replacements;

        #endregion

        #region "Constructor"

        public RegisterConverter()
        {
            m_types = new List<string>(0);
            /* Add common type */
            AddTypeToReplace("uint32_t");
            /* Default variable header */
            VariableHeader = "m_";
            /* Init replacements to 0 */
            m_replacements = 0;
        }

        #endregion

        #region "Public Functions"

        public void Convert(string SourceFilePath, string DestFilePath, bool OverWriteExistingFile)
        {
            StreamReader reader;
            StreamWriter writer;

            /* Check that source exists */
            if (!File.Exists(SourceFilePath))
                throw new ArgumentException("ERROR: File " + SourceFilePath + " does not exist!");

            /* If destination file exists and no overwrite then throw an exception */
            if(!OverWriteExistingFile && File.Exists(DestFilePath))
                throw new ArgumentException("ERROR: Destination file " + SourceFilePath + " already exists!");

            /* Create reader/writer */
            reader = new StreamReader(SourceFilePath);
            writer = new StreamWriter(DestFilePath, false);

            /* Reset replacements to 0 */
            m_replacements = 0;

            /* Process through file */
            while(!reader.EndOfStream)
            {
                writer.WriteLine(ProcessLine(reader.ReadLine()));
            }
            /* Close when done */
            reader.Close();
            writer.Close();
        }

        public string VariableHeader
        {
            get
            {
                return m_variableHeader;
            }
            set
            {
                if(value.Length < 1)
                {
                    throw new ArgumentException("ERROR: Generated variable header must be at least one character");
                }
                m_variableHeader = value;
            }
        }

        public IEnumerable<string> GetTypesToReplace
        {
            get
            {
                return m_types;
            }
        }

        public void AddTypeToReplace(string TypeName)
        {
            m_types.Add(TypeName);
        }

        public void ClearTypesToReplace()
        {
            m_types.Clear();
        }

        public int NumReplacements
        {
            get
            {
                return m_replacements;
            }
        }

        #endregion

        #region "Private Functions"

        private string ProcessLine(string Line)
        {
            StringBuilder defineTarget = new StringBuilder();
            StringBuilder defineName = new StringBuilder();
            string defineType = "";
            char currentChar;
            string modifiedLine = Line;
            int defineIndex, index;

            /*check if line contains #define*/
            defineIndex = Line.IndexOf("#define");

            if(defineIndex != -1)
            {
                /* Get index after #define */
                index = defineIndex + 7;

                /* Find the define name */
                currentChar = Line[index];
                while(char.IsWhiteSpace(currentChar) && index < Line.Length)
                {
                    index++;
                    currentChar = Line[index];
                }
                /* index is on first value in define name now */
                while (!char.IsWhiteSpace(currentChar) && index < Line.Length)
                {
                    defineName.Append(currentChar);
                    index++;
                    currentChar = Line[index];
                }
                /* Make sure we haven't parsed entire line */
                if (index == Line.Length)
                    return Line;

                /* Find the define type */
                for(int i = 0; i < m_types.Count(); i++)
                {
                    if (Line.Contains(m_types[i]))
                        defineType = m_types[i];
                }
                if (defineType == "")
                    return Line;

                /* Check that it is pointer type */
                index = Line.IndexOf(defineType) + defineType.Length;

                /* Find define target value */


            }
            else
            {
                /* Line doesn't contain a define */
                return Line;
            }

            /* Build result */
            m_replacements++;
            return "extern " + defineType + " " + VariableHeader + defineName.ToString() + ";" + " /* The line has been auto-generated to allow register replacement in Tessy */" + Environment.NewLine + modifiedLine;
        }

        #endregion
    }
}
