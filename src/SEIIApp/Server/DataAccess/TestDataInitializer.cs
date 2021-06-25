using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEIIApp.Server.Domain;
using SEIIApp.Shared.DomainTdo;

namespace SEIIApp.Server.DataAccess {

    public static class TestDataInitializer {

        /// <summary>
        /// Initialze test data (just for in-memory database)
        ///    --> IMPORTANT: when the testdata isnt really correctly instantiated, the error that follows isn't really
        ///    traceable to here
        /// </summary>
        public static void InitializeTestData(Services.CourseDefinitionService courseDefinitionService,  Services.ChapterDefinitionService chapterDefinitionService, 
            Services.ChapterElementDefinitionService chapterElementDefinitionService, Services.LoginService loginService, Services.UserDefinitionService userDefinitionService) {

            var authTest = TestDataGenerator.CreateAuthentifizierung("test", "test", RoleType.Student);
            loginService.AddAuth(authTest);

            var authAdmin2 = TestDataGenerator.CreateAuthentifizierung("admin", "admin", RoleType.Admin);
            loginService.AddAuth(authAdmin2);
            
            var authTeacher2 = TestDataGenerator.CreateAuthentifizierung("teacher", "teacher", RoleType.Teacher);
            loginService.AddAuth(authTeacher2);

            var userAdmin = TestDataGenerator.CreateUser("adminMail@mailinator.com");
            var authAdmin = TestDataGenerator.CreateAuthentifizierung("admin", "admin", RoleType.Admin);
            userAdmin.AuthDefinitions.Add(authAdmin);
            userAdmin.AuthDefinitions.Add(authAdmin2);

            var authStudent2 = TestDataGenerator.CreateAuthentifizierung("user", "user", RoleType.Student);
            loginService.AddAuth(authStudent2);
            var userStudent = TestDataGenerator.CreateUser("studentMail@mailinator.com");
            var authStudent = TestDataGenerator.CreateAuthentifizierung("student", "student", RoleType.Student);
            userStudent.AuthDefinitions.Add(authStudent);
            userStudent.AuthDefinitions.Add(authStudent2);

            var userTeacher = TestDataGenerator.CreateUser("teacherMail@mailinator.com");
            var authTeacher = TestDataGenerator.CreateAuthentifizierung("teacher", "teacher", RoleType.Teacher);
            userTeacher.AuthDefinitions.Add(authTeacher);
            userTeacher.AuthDefinitions.Add(authTeacher2);


            for (int i = 0; i < 5; i++) {

                var course = TestDataGenerator.CreateCourseDefinition("Course " + i);
                courseDefinitionService.AddCourse(course);

                for (int j = 0; j < 3; j++)
                {
                    var chapter = TestDataGenerator.CreateChapterDefinition("Chapter " + i);
                    chapterDefinitionService.Addchapter(chapter);
                    course.Chapters.Add(chapter);


                    for (int k = 0; k < 6; k++)
                    {
                        ChapterElementDefinition element;

                        if (k == 1 || k == 2)
                        {
                            element = TestDataGenerator.CreateExplanatoryTextDefinition("ExampleText" + k);
                            element.ChapterElementType = Shared.DomainTdo.ChapterElementType.Text;
                        } else if(k == 3 || k == 4)
                        {
                            element = TestDataGenerator.CreatePictureDefinition("ExamplePicture" + k);
                            element.ChapterElementType = Shared.DomainTdo.ChapterElementType.Picture;
                        }else
                        {
                            var quiz = TestDataGenerator.CreateQuizDefinition();
                            quiz.QuizName = "Quiz " + k;
                            element = quiz;
                            element.ChapterElementType = Shared.DomainTdo.ChapterElementType.Quiz;
                        }

                        chapterElementDefinitionService.AddChapterElement(element);
                        chapter.ChapterElements.Add(element);
                        // TODO: add videoelement
                    }

                }

                var courseId = new AsignedCoursesIdClass();
                courseId.AsignedCoursesId = course.CourseId;
                userAdmin.AsignedCoursesId.Add(courseId);


                if (i == 0 || i == 1)
                {
                    var courseIdVar1 = new AsignedCoursesIdClass();
                    courseIdVar1.AsignedCoursesId = course.CourseId;
                    userStudent.AsignedCoursesId.Add(courseIdVar1);
                }
                if(i == 0 || i == 1 || i== 2)
                {
                    var courseIdVar2 = new AsignedCoursesIdClass();
                    courseIdVar2.AsignedCoursesId = course.CourseId;
                    userTeacher.AsignedCoursesId.Add(courseIdVar2);
                }

            }
            userDefinitionService.AddUser(userAdmin);
            userDefinitionService.AddUser(userStudent);
            userDefinitionService.AddUser(userTeacher);

        }


        /// <summary>
        /// Initialze USEFULL test data (just for in-memory database)
        ///
        /// Content in large parts from
        /// https://www.mayoclinic.org/diseases-conditions/premature-birth/symptoms-causes/syc-20376730
        /// and https://healthywa.wa.gov.au/Articles/A_E/Diagnostic-tests-for-your-baby-during-pregnancy
        /// </summary>
        public static void InitializeUsefullTestData(Services.CourseDefinitionService courseDefinitionService, Services.ChapterDefinitionService chapterDefinitionService,
            Services.ChapterElementDefinitionService chapterElementDefinitionService, Services.LoginService loginService, Services.UserDefinitionService userDefinitionService)
        {
            string newLine = Environment.NewLine;

            // ============= COURSE - Reanimation ==================
            var courseReanimation = TestDataGenerator.CreateCourseDefinition("Reanimation");
            courseDefinitionService.AddCourse(courseReanimation);

            // ------------- chapter - Respiration -----------------
            var chapterRespiration = TestDataGenerator.CreateChapterDefinition("Respiration");
            chapterDefinitionService.Addchapter(chapterRespiration);
            courseReanimation.Chapters.Add(chapterRespiration);

            var respirationText = TestDataGenerator.CreateExplanatoryTextDefinition("Content:");
            respirationText.ContentText = "This chapter contains a quiz about some respiration techniques. Please don't look up any answers, but rather use your own kwowledge!";

            var respirationQuiz = new QuizDefinition();
            respirationQuiz.QuizName = "Respiration Quiz";

            var question1 = new QuestionDefinition();
            question1.QuestionText = "Bei der Reanimation von Neugeborenen unmittelbar nach Geburt ist das Verhältnis von Beatmungshüben zu Thoraxkompressionen:";
            var answer11 = new AnswerDefinition();
            answer11.AnswerText = "Beatmung : Kompression = 2:30";
            var answer12 = new AnswerDefinition();
            answer12.AnswerText = "Beatmung : Kompression = 2:15";
            var answer13 = new AnswerDefinition();
            answer13.AnswerText = "Beatmung : Kompression = 1:3";
            var answer14 = new AnswerDefinition();
            answer14.AnswerText = "Beatmung : Kompression = 1:15";
            var answer15 = new AnswerDefinition();
            answer15.AnswerText = "Beatmung : Kompression = 2:3";
            question1.Answers = new List<AnswerDefinition>();
            question1.Answers.Add(answer11);
            question1.Answers.Add(answer12);
            question1.Answers.Add(answer13);
            question1.Answers.Add(answer14);
            question1.Answers.Add(answer15);

            var question2 = new QuestionDefinition();
            question2.QuestionText = "Für den Erfolg der Beatmungsmaßnahmen gilt beim Neugeborenen? (Es können mehrere Antworten richtig sein.)";
            var answer21 = new AnswerDefinition();
            answer21.AnswerText = "Eine Flexion des Kopfes ist zu vermeiden.";
            var answer22 = new AnswerDefinition();
            answer22.AnswerText = "Eine Reklination des Kopfes ist zu vermeiden.";
            var answer23 = new AnswerDefinition();
            answer23.AnswerText = "Die Dichtigkeit der Beatmungsmaske kann durch eine 2-Helfer Methode verbessert werden.";
            var answer24 = new AnswerDefinition();
            answer24.AnswerText = "Nur nach gründlichem Absaugen können Beatmungsmaßnahmen effektiv durchgeführt werden.";
            var answer25 = new AnswerDefinition();
            answer25.AnswerText = "Die invasive Ventilation über einen Endotrachealtubus zeigt einen deutlichen Überlebensvorteil gegenüber der Beutel-Maske- Beatmung.";
            question2.Answers = new List<AnswerDefinition>();
            question2.Answers.Add(answer21);
            question2.Answers.Add(answer22);
            question2.Answers.Add(answer23);
            question2.Answers.Add(answer24);
            question2.Answers.Add(answer25);

            respirationQuiz.Questions = new List<QuestionDefinition>();
            respirationQuiz.Questions.Add(question1);
            respirationQuiz.Questions.Add(question2);

            respirationText.ChapterElementType = ChapterElementType.Text;
            chapterElementDefinitionService.AddChapterElement(respirationText);
            chapterRespiration.ChapterElements.Add(respirationText);

            respirationQuiz.ChapterElementType = ChapterElementType.Quiz;
            chapterElementDefinitionService.AddChapterElement(respirationQuiz);
            chapterRespiration.ChapterElements.Add(respirationQuiz);


            // ============= COURSE - Premature birth ==============
            var coursePrematureBirth = TestDataGenerator.CreateCourseDefinition("Premature birth");
            courseDefinitionService.AddCourse(coursePrematureBirth);

            // ------------- chapter - risks -----------------------
            var chapterRisks = TestDataGenerator.CreateChapterDefinition("Riskfactors");
            chapterDefinitionService.Addchapter(chapterRisks);
            coursePrematureBirth.Chapters.Add(chapterRisks);

            var riskText1 = TestDataGenerator.CreateExplanatoryTextDefinition("Some of the known risk factors of premature delivery:");
            riskText1.ContentText = "- Having a previous premature birth" + newLine + "- Pregnancy with twins, triplets or other multiples" + newLine +
                "- An interval of less than six months between pregnancies" + newLine + "- Physical injury or trauma" + newLine +
                "- Being underweight or overweight before pregnancy" + newLine + "- Stressful life events, such as the death of a loved one or domestic violence";

            var riskText2 = TestDataGenerator.CreateExplanatoryTextDefinition("Important:");
            riskText2.ContentText = "However, often the specific cause of premature birth is not clear!";

            riskText1.ChapterElementType = ChapterElementType.Text;
            chapterElementDefinitionService.AddChapterElement(riskText1);
            chapterRisks.ChapterElements.Add(riskText1);

            riskText2.ChapterElementType = ChapterElementType.Text;
            chapterElementDefinitionService.AddChapterElement(riskText2);
            chapterRisks.ChapterElements.Add(riskText2);

            // ------------- chapter - symptoms -----------------------
            var chapterSymptoms = TestDataGenerator.CreateChapterDefinition("Symptoms");
            chapterDefinitionService.Addchapter(chapterSymptoms);
            coursePrematureBirth.Chapters.Add(chapterSymptoms);

            var symptomsText = TestDataGenerator.CreateExplanatoryTextDefinition("Some signs can include:");
            symptomsText.ContentText = "- Small size, with a disproportionately large head" + newLine + "- Sharper looking, less rounded features than a full-term baby's features, due to a lack of fat stores" + newLine +
                "- Fine hair (lanugo) covering much of the body" + newLine + "- Labored breathing or respiratory distress" + newLine +
                "- Lack of reflexes for sucking and swallowing, leading to feeding difficulties";

            symptomsText.ChapterElementType = ChapterElementType.Text;
            chapterElementDefinitionService.AddChapterElement(symptomsText);
            chapterSymptoms.ChapterElements.Add(symptomsText);

            // ------------- chapter - complications -------------------
            var chapterComplications = TestDataGenerator.CreateChapterDefinition("Complications");
            chapterDefinitionService.Addchapter(chapterComplications);
            coursePrematureBirth.Chapters.Add(chapterComplications);

            var complicationsText1 = TestDataGenerator.CreateExplanatoryTextDefinition("General:");
            complicationsText1.ContentText = "While not all premature babies experience complications, being born too early can cause short-term and long-term " +
                "health problems. Generally, the earlier a baby is born, the higher the risk of complications. Birth weight plays an important role, too.";

            var complicationsText2 = TestDataGenerator.CreateExplanatoryTextDefinition("Breathing problems");
            complicationsText2.ContentText = "A premature baby may have trouble breathing due to an immature respiratory system. If the baby's lungs lack surfactant — " +
                "a substance that allows the lungs to expand — he or she may develop respiratory distress syndrome because the lungs can't expand and contract normally." + newLine +
                "Premature babies may also develop a lung disorder known as bronchopulmonary dysplasia. In addition, some preterm babies may experience prolonged pauses in their" +
                " breathing, known as apnea.";

            var complicationsText3 = TestDataGenerator.CreateExplanatoryTextDefinition("Heart problems");
            complicationsText3.ContentText = "The most common heart problems premature babies experience are patent ductus arteriosus (PDA) and low blood pressure (hypotension). PDA is a " +
                "persistent opening between the aorta and pulmonary artery. While this heart defect often closes on its own, left untreated it can lead to a heart murmur, heart failure as " +
                "well as other complications. Low blood pressure may require adjustments in intravenous fluids, medicines and sometimes blood transfusions.";

            var complicationsText4 = TestDataGenerator.CreateExplanatoryTextDefinition("Brain problems");
            complicationsText4.ContentText = "The earlier a baby is born, the greater the risk of bleeding in the brain, known as an intraventricular hemorrhage. Most hemorrhages are mild " +
                "and resolve with little short-term impact. But some babies may have larger brain bleeding that causes permanent brain injury.";

            var complicationsText5 = TestDataGenerator.CreateExplanatoryTextDefinition("Immune system problems");
            complicationsText5.ContentText = "An underdeveloped immune system, common in premature babies, can lead to a higher risk of infection. Infection in a premature baby can quickly " +
                "spread to the bloodstream, causing sepsis, an infection that spreads to the bloodstream.";

            var complicationsText6 = TestDataGenerator.CreateExplanatoryTextDefinition("Short-term vs. long-term complications:");
            complicationsText6.ContentText = "However, next to these short term complications there are also long term complications, including cerebral palsy, vision problems, hearing problems" +
                "and others as well.";

            complicationsText1.ChapterElementType = ChapterElementType.Text;
            chapterElementDefinitionService.AddChapterElement(complicationsText1);
            chapterComplications.ChapterElements.Add(complicationsText1);

            complicationsText2.ChapterElementType = ChapterElementType.Text;
            chapterElementDefinitionService.AddChapterElement(complicationsText2);
            chapterComplications.ChapterElements.Add(complicationsText2);

            complicationsText3.ChapterElementType = ChapterElementType.Text;
            chapterElementDefinitionService.AddChapterElement(complicationsText3);
            chapterComplications.ChapterElements.Add(complicationsText3);

            complicationsText4.ChapterElementType = ChapterElementType.Text;
            chapterElementDefinitionService.AddChapterElement(complicationsText4);
            chapterComplications.ChapterElements.Add(complicationsText4);

            complicationsText5.ChapterElementType = ChapterElementType.Text;
            chapterElementDefinitionService.AddChapterElement(complicationsText5);
            chapterComplications.ChapterElements.Add(complicationsText5);

            complicationsText6.ChapterElementType = ChapterElementType.Text;
            chapterElementDefinitionService.AddChapterElement(complicationsText6);
            chapterComplications.ChapterElements.Add(complicationsText6);

            // ------------- chapter - prevention -----------------------
            var chapterPrevention = TestDataGenerator.CreateChapterDefinition("Prevention");
            chapterDefinitionService.Addchapter(chapterPrevention);
            coursePrematureBirth.Chapters.Add(chapterPrevention);

            var preventionText1 = TestDataGenerator.CreateExplanatoryTextDefinition("General:");
            preventionText1.ContentText = "Although the exact cause of preterm birth is often unknown, there are some things that can be done to help women — especially those " +
                "who have an increased risk — to reduce their risk of preterm birth, including:";

            var preventionText2 = TestDataGenerator.CreateExplanatoryTextDefinition("Progesterone supplements");
            preventionText2.ContentText = "Women who have a history of preterm birth, a short cervix or both factors may be able to reduce the risk of preterm birth " +
                "with progesterone supplementation.";

            var preventionText3 = TestDataGenerator.CreateExplanatoryTextDefinition("Cervical cerclage");
            preventionText3.ContentText = "This is a surgical procedure performed during pregnancy in women with a short cervix, or a history of cervical shortening that resulted in a preterm birth." + newLine +
                "During this procedure, the cervix is stitched closed with strong sutures that may provide extra support to the uterus. The sutures are removed when it's time to deliver the baby. Ask your " +
                "doctor if you need to avoid vigorous activity during the remainder of your pregnancy.";

            preventionText1.ChapterElementType = ChapterElementType.Text;
            chapterElementDefinitionService.AddChapterElement(preventionText1);
            chapterPrevention.ChapterElements.Add(preventionText1);

            preventionText2.ChapterElementType = ChapterElementType.Text;
            chapterElementDefinitionService.AddChapterElement(preventionText2);
            chapterPrevention.ChapterElements.Add(preventionText2);

            preventionText3.ChapterElementType = ChapterElementType.Text;
            chapterElementDefinitionService.AddChapterElement(preventionText3);
            chapterPrevention.ChapterElements.Add(preventionText3);


            // ============= COURSE - Diagnostic tests =============
            var courseDiagnosticTests = TestDataGenerator.CreateCourseDefinition("Diagnostic tests");
            courseDefinitionService.AddCourse(courseDiagnosticTests);

            // ------------- chapter - General -----------------
            var chapterGeneral = TestDataGenerator.CreateChapterDefinition("General");
            chapterDefinitionService.Addchapter(chapterGeneral);
            courseDiagnosticTests.Chapters.Add(chapterGeneral);

            var generalText1 = TestDataGenerator.CreateExplanatoryTextDefinition("Reasons to choose a diagnostics test:");
            generalText1.ContentText = "- If you had a previous pregnancy with Down syndrome or other birth defect" + newLine +
                "- If you've been identified as at increased risk of having a baby with a genetic condition after a first or second trimester screening test" + newLine +
                "- If you have a family history of a genetic condition";

            var generalText2 = TestDataGenerator.CreateExplanatoryTextDefinition("Different methods:");
            generalText1.ContentText = "In the following chapters some of the available methods are explained more in depth.";

            generalText1.ChapterElementType = ChapterElementType.Text;
            chapterElementDefinitionService.AddChapterElement(generalText1);
            chapterGeneral.ChapterElements.Add(generalText1);

            generalText2.ChapterElementType = ChapterElementType.Text;
            chapterElementDefinitionService.AddChapterElement(generalText2);
            chapterGeneral.ChapterElements.Add(generalText2);

            // ------------- chapter - Amniocentesis -----------
            var chapterAmniocentesis = TestDataGenerator.CreateChapterDefinition("Amniocentesis");
            chapterDefinitionService.Addchapter(chapterAmniocentesis);
            courseDiagnosticTests.Chapters.Add(chapterAmniocentesis);

            var amniocentesisText = TestDataGenerator.CreateExplanatoryTextDefinition("General informations:");
            amniocentesisText.ContentText = "This test is done between weeks 15 to 18 of a pregnancy." + newLine +
                "A needle, guided by ultrasound to avoid harming your developing baby, is inserted through your abdomen (stomach) to take a small sample of amniotic fluid (the fluid that surrounds " +
                "the baby in the uterus).This sample is tested for missing, extra or abnormal chromosomes." + newLine +
                "Amniocentesis is an outpatient procedure that takes about 20 minutes. You will be awake during the procedure. Many women find the diagnostic tests uncomfortable and this discomfort is " +
                "often managed by local anaesthetic. It is suggested you rest for about 20 minutes after the procedure and take things easy for 1 to 2 days after the tests." + newLine +
                "The risk of pregnancy loss (miscarriage) is less than 1 in 100 (less than 1 per cent).";

            var amniocentesisPic = TestDataGenerator.CreatePictureDefinition("From Royal College of Obstetricians and Gynaecologists Figure 3: Amniocentesis");
            amniocentesisPic.PictureUri = new Uri("https://healthywa.wa.gov.au/-/media/Images/HealthyWA/Articles/Having-a-baby/amniocentesis-diagram.jpg");

            amniocentesisText.ChapterElementType = ChapterElementType.Text;
            chapterElementDefinitionService.AddChapterElement(amniocentesisText);
            chapterAmniocentesis.ChapterElements.Add(amniocentesisText);

            amniocentesisPic.ChapterElementType = ChapterElementType.Picture;
            chapterElementDefinitionService.AddChapterElement(amniocentesisPic);
            chapterAmniocentesis.ChapterElements.Add(amniocentesisPic);

            // ------------- chapter - Chorionic ---------------
            var chapterChorionic = TestDataGenerator.CreateChapterDefinition("Chorionic");
            chapterDefinitionService.Addchapter(chapterChorionic);
            courseDiagnosticTests.Chapters.Add(chapterChorionic);

            var chorionicText = TestDataGenerator.CreateExplanatoryTextDefinition("General informations:");
            chorionicText.ContentText = "This test is done between weeks 11 to 14 of a pregnancy." + newLine +
                "A needle, guided by ultrasound to avoid harming your developing baby, is inserted through your abdomen (stomach) or cervix to take a sample of chorionic villus cells from your " +
                "placenta. This sample is tested for missing, extra or abnormal chromosomes." + newLine +
                "The test is done as an outpatient procedure (you won’t need to be admitted to hospital) and takes about 20 minutes. You will be awake during the " +
                "procedure. Many women find the diagnostic tests uncomfortable and this discomfort is often managed by local anaesthetic. It is suggested you rest " +
                "for about 20 minutes after the procedure and take things easy for 1 to 2 days after the test." + newLine +
                "The risk of pregnancy loss (miscarriage) from this procedure is less than 1 in 100 (less than 1 per cent).";

            var chorionicPic1 = TestDataGenerator.CreatePictureDefinition("From Royal College of Obstetricians and Gynaecologists Figure 1: Chorionic villus sampling through the abdomen");
            chorionicPic1.PictureUri = new Uri("https://healthywa.wa.gov.au/-/media/Images/HealthyWA/Articles/Having-a-baby/chorionic-villus-sampling-abdomen.jpg");

            var chorionicPic2 = TestDataGenerator.CreatePictureDefinition("From Royal College of Obstetricians and Gynaecologists Figure 2: Chorionic villus sampling through the cervix(entrance to the womb)");
            chorionicPic2.PictureUri = new Uri("https://healthywa.wa.gov.au/-/media/Images/HealthyWA/Articles/Having-a-baby/chorionic-villus-sampling-cervix.jpg");

            var chorionicVid = TestDataGenerator.CreateVideoDefinition("Advanced prenatal genetic testing");
            chorionicVid.VideoUri = new Uri("https://www.youtube.com/embed/bvVrFSBnbvM");

            chorionicText.ChapterElementType = ChapterElementType.Text;
            chapterElementDefinitionService.AddChapterElement(chorionicText);
            chapterChorionic.ChapterElements.Add(chorionicText);

            chorionicPic1.ChapterElementType = ChapterElementType.Picture;
            chapterElementDefinitionService.AddChapterElement(chorionicPic1);
            chapterChorionic.ChapterElements.Add(chorionicPic1);

            chorionicPic2.ChapterElementType = ChapterElementType.Picture;
            chapterElementDefinitionService.AddChapterElement(chorionicPic2);
            chapterChorionic.ChapterElements.Add(chorionicPic2);

            chorionicVid.ChapterElementType = ChapterElementType.Video;
            chapterElementDefinitionService.AddChapterElement(chorionicVid);
            chapterChorionic.ChapterElements.Add(chorionicVid);


            // =============== USER CREATION ===================

            var authTest = TestDataGenerator.CreateAuthentifizierung("test", "test", RoleType.Student);
            loginService.AddAuth(authTest);

            var authAdmin2 = TestDataGenerator.CreateAuthentifizierung("admin", "admin", RoleType.Admin);
            loginService.AddAuth(authAdmin2);

            var authTeacher2 = TestDataGenerator.CreateAuthentifizierung("teacher", "teacher", RoleType.Teacher);
            loginService.AddAuth(authTeacher2);

            var userAdmin = TestDataGenerator.CreateUser("adminMail@mailinator.com");
            var authAdmin = TestDataGenerator.CreateAuthentifizierung("admin", "admin", RoleType.Admin);
            userAdmin.AuthDefinitions.Add(authAdmin);
            userAdmin.AuthDefinitions.Add(authAdmin2);

            var authStudent2 = TestDataGenerator.CreateAuthentifizierung("user", "user", RoleType.Student);
            loginService.AddAuth(authStudent2);
            var userStudent = TestDataGenerator.CreateUser("studentMail@mailinator.com");
            var authStudent = TestDataGenerator.CreateAuthentifizierung("student", "student", RoleType.Student);
            userStudent.AuthDefinitions.Add(authStudent);
            userStudent.AuthDefinitions.Add(authStudent2);

            var userTeacher = TestDataGenerator.CreateUser("teacherMail@mailinator.com");
            var authTeacher = TestDataGenerator.CreateAuthentifizierung("teacher", "teacher", RoleType.Teacher);
            userTeacher.AuthDefinitions.Add(authTeacher);
            userTeacher.AuthDefinitions.Add(authTeacher2);

         
            // =============== COURSE ASIGNATION ==============

            // --------------- for admin ----------------------
            var courseId_A1 = new AsignedCoursesIdClass();
            courseId_A1.AsignedCoursesId = courseReanimation.CourseId;
            userAdmin.AsignedCoursesId.Add(courseId_A1);

            var courseId_A2 = new AsignedCoursesIdClass();
            courseId_A2.AsignedCoursesId = coursePrematureBirth.CourseId;
            userAdmin.AsignedCoursesId.Add(courseId_A2);

            var courseId_A3 = new AsignedCoursesIdClass();
            courseId_A3.AsignedCoursesId = courseDiagnosticTests.CourseId;
            userAdmin.AsignedCoursesId.Add(courseId_A3);

            // --------------- for teacher --------------------
            var courseId_T1 = new AsignedCoursesIdClass();
            courseId_T1.AsignedCoursesId = courseReanimation.CourseId;
            userTeacher.AsignedCoursesId.Add(courseId_T1);

            var courseId_T2 = new AsignedCoursesIdClass();
            courseId_T2.AsignedCoursesId = coursePrematureBirth.CourseId;
            userTeacher.AsignedCoursesId.Add(courseId_T2);

            var courseId_T3 = new AsignedCoursesIdClass();
            courseId_T3.AsignedCoursesId = courseDiagnosticTests.CourseId;
            userTeacher.AsignedCoursesId.Add(courseId_T3);

            // --------------- for student --------------------
            var courseId_S1 = new AsignedCoursesIdClass();
            courseId_S1.AsignedCoursesId = coursePrematureBirth.CourseId;
            userStudent.AsignedCoursesId.Add(courseId_S1);


            userDefinitionService.AddUser(userAdmin);
            userDefinitionService.AddUser(userStudent);
            userDefinitionService.AddUser(userTeacher);

        }

    }

}
