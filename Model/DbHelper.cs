using MapApi1.EfCore;

namespace MapApi1.Model
{
    public class DbHelper
    {
        private EF_DataContext _context;
        public DbHelper(EF_DataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// GET
        /// </summary>
        /// <returns></returns>
        public List<PointModel> GetPoints()
        {
            List<PointModel> response = new List<PointModel>();
            var dataList = _context.Points.ToList();
            dataList.ForEach(row => response.Add(new PointModel()
            {
                id = row.id,
                name = row.name,
                wkt = row.wkt,
            }));
            return response;
        }

        public PointModel GetPointById(int id)
        {
            PointModel response = new PointModel();
            var row = _context.Points.Where(d => d.id.Equals(id)).FirstOrDefault();
            return new PointModel()
            {
                id = row.id,
                name = row.name,
                wkt = row.wkt
            };
        }

        /// <summary>
        /// It serves the POST/PUT/PATCH
        /// </summary>
        public void SavePoint(PointModel pointModel)
        {
            Point dbTable = new Point();
    
            //PUT
            dbTable = _context.Points.Where(d => d.id.Equals(pointModel.id)).FirstOrDefault();
            if (dbTable != null)
                {
                    dbTable.id = pointModel.id;
                    dbTable.name = pointModel.name;
                    dbTable.wkt = pointModel.wkt;
                }
            else
            {
                dbTable = new Point();
                //POST
                dbTable.name = pointModel.name;
                dbTable.wkt = pointModel.wkt;
                _context.Points.Add(dbTable);
            }
            
            _context.SaveChanges();
           
        }
        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public void DeletePoint(int id)
        {
            var point = _context.Points.Where(d => d.id.Equals(id)).FirstOrDefault();
            if (point != null)
            {
                _context.Points.Remove(point);
                _context.SaveChanges();
            }
        }
    }
}