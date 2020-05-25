        /// <summary>
        /// Convert a UTC Date String of format yyyyMMddTHHmmZ into a Local Date
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public DateTime BuildDateTimeFromYAFormat(string dateString)
        {
            Regex r = new Regex(@"^\d{4}\d{2}\d{2}T\d{2}\d{2}\d{2}Z$");
            if (!r.IsMatch(dateString))
            {
                throw new FormatException(
                    string.Format("{0} is not the correct format. Should be yyyyMMddTHHmmssZ", dateString));
            }

            // in israel will add 2 hours forward +2
            DateTime dt = DateTime.ParseExact(dateString, "yyyyMMddTHHmmssZ", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);

            return dt;
        }
        
        ///  Demo url: http://localhost:[Port]/api/purchase/getfromdate?startDate=20191126T140931Z
        ///  moving +2 hours forward due to time zone
        [HttpGet]
        [Route("api/purchase/getfromdate")]
        public IHttpActionResult StartFromDate([FromUri]string startDate)
        {
            try
            {
                // need to validate parameters before continue ...
                if (bulkSize <= 0)
                    return BadRequest("bulk size must be greater euqal than 1");

                var startDateDT = BuildDateTimeFromYAFormat(startDate);

                // ...
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex); // +also write to log file

                // consider which error to send to customer
                // choose between bad-request and internal-error
                return BadRequest("Something went wrong ... check the parameter you send. please contact support");
            }

        }
        
