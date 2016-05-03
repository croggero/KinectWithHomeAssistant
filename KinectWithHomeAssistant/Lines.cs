using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;
using System.Windows.Media.Media3D;

namespace KinectWithHomeAssistant
{
    class ObjLine
    {
        private Point3D objPoint = new Point3D();
        private Vector3D objVector = new Vector3D();

        // Takes in elbow point and hand point to determine vectors
        public ObjLine(CameraSpacePoint Point_1, CameraSpacePoint Point_2)
        {
            objPoint.X = Point_1.X;
            objPoint.Y = Point_1.Y;
            objPoint.Z = Point_1.Z;

            objVector.X = Point_2.X - Point_1.X;
            objVector.Y = Point_2.Y - Point_1.Y;
            objVector.Z = Point_2.Z - Point_2.Z;
        }

        public Point3D Point { get { return objPoint; } }

        public Vector3D Vector { get { return objVector; } }


        public Point3D LineIntersect(ObjLine Line)
        {
            // Find new cross product of the lines
            Vector3D perpendicularFromLine1ToLine2 = Vector3D.CrossProduct(Line.Vector, Vector3D.CrossProduct(this.Vector, Line.Vector));
            Vector3D perpendicularFromLine2ToLine1 = Vector3D.CrossProduct(this.Vector, Vector3D.CrossProduct(Line.Vector, this.Vector));

            // Use Max Coordinates if lines are parallel
            if (perpendicularFromLine1ToLine2 == new Vector3D(0, 0, 0))
            {
                return new Point3D(double.MaxValue, double.MaxValue, double.MaxValue);
            }

            // Finds ths othogonal projections, QP and PQ
            Vector3D orthoVector1 = new Vector3D(Line.Point.X - this.Point.X, Line.Point.Y - this.Point.Y, Line.Point.Z - Line.Point.Z);
            Vector3D orthoVector2 = new Vector3D(this.Point.X - Line.Point.X, this.Point.Y - Line.Point.Y, this.Point.Z - Line.Point.Z);

            // Create dot product of two lines
            double dotProduct1 = Vector3D.DotProduct(perpendicularFromLine1ToLine2, orthoVector1);
            double dotProduct2 = Vector3D.DotProduct(perpendicularFromLine2ToLine1, orthoVector2);

            // Find positions of points
            Point3D point1 = Line.Point + Vector3D.Multiply(Line.Vector, dotProduct1);
            Point3D point2 = Line.Point + Vector3D.Multiply(Line.Vector, dotProduct2);

            double midX = (point1.X + point2.X) / 2;
            double midY = (point1.Y + point2.Y) / 2;
            double midZ = (point1.Z + point2.Z) / 2;

            // Return mid point
            return new Point3D(midX, midY, midZ);
        }
    }
}
