using System;
using System.Collections.Generic;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace WorkingWithImages
{
    class Program
    {
        static void Main(string[] args)
        {
            string imagePathFolder = Path.Combine(Environment.CurrentDirectory, "images");
            /*
            هنا استخدمنا دالة الكومباين اللي في كلاس باث ومهمتها هو دمج مسارين او اكثر 
            هنا اول معامل هو المسار الحالي للمجلد اللي نحن فيه بايجيبه
            ثم بايعمل / ويلحق اسم مجلد الصور فيه 
            لذلك الهدف من الكود هو ارجاع المسار الكامل للمجلد اللي حطينا فيه الصور
            */

            IEnumerable<string> imagesPaths = Directory.EnumerateFiles(imagePathFolder);
            /*
            لاننا نتعامل مع عدد كبير من الملفات فلازم نجعلها اشبه بلسته بحيث نقدر 
            نمر عليها او نعمل عليها تكرار ومن اجل هذا استخدمنا الانترفيس انيمرابل
            حيث سيحوي المتغير الاميجزباثس على مسارات كل الصور اللي في المجلد
            */

            foreach (string imagePath in imagesPaths) // نعمل لووب على كل اللسته اي كل المفات
            {
                 string pathsAfterChangeName = Path.Combine(Environment.CurrentDirectory, "images", Path.GetFileNameWithoutExtension(imagePath) + "-thumbnail" + Path.GetExtension(imagePath));
                    /*
                     هنا نريد عمل تعديل باسماء الصور بحيث انه لاحقا لا نريد حفظ التعديلات 
                      على الصور الاصلية وانما نريد حفظها كنسخة باسم اخر
                      اللي سنعمله هنا سنستخدم نفس دالة دمج المسارات
                      حيث بانجيب مسار المجلد الحالي للمشروع ثم سلاش نلحقه باسم مجلد الصور اميجس
                      وهو البرميتر الثاني اما الثالث فهو اسم الملف اي الصور وسنعدل فيه
                      ثم نجيب  اسم الملفات اي الصور بدون امتداد
                      ثم يلحقها بالاندرسكرول فكلمة ثمبنل 
                      ثم يجيب الامتداد حق الصورة ويلحقه فيه 

                    */
 
                using (Image image = Image.Load(imagePath)) // هذه طريقة اليوسنج للامان بدل التراي والكاتش
                { // هنا حمل الملفات عبر تمرير مسارها الاصلي
                 // الدالتين الاتية تعملان على تحجيم الصورة ثم اضفاء اللون الرمادي عليها
                    image.Mutate(x => x.Resize(image.Width / 10, image.Height / 10));
                    image.Mutate(x => x.Grayscale());
                    /* هنا نريد انه نحفظ بالاسم البديل اللي عدلناه
                     اذا حفظنا مباشرة بالاسم اميج باث اللي في الفوراتش فسنعدل بالصور الاصلية نفسها
                      وليس نسخة منها
                    */
                    image.Save(pathsAfterChangeName);
                }
 
            }

        }
    }
}
