# Readme ALEXANDRIA

This Project contains the webapp for the learningplattform ALEXANDRIA
frontend and backend.

# 1 PressRelease

### Einfache Content Creation für Wissensvermittlung in kürzester Zeit mit *Alexandria*

*Mit einem einfachen Baukastensystem lassen sich viele verschiedene Blöcke an Lerninhalten und Wissensinhalten zu fertigen Lernkursen zusammenführen.*

MÜNCHEN - 26.05.2021 - Um im Rahmen des Partnerprojekts JimmaNeo auch während der Corona Pandemie weiterhin praktisches Wissen zur Versorgung von Neugeborenen vermitteln zu können, bedarf es einer Alternative zu den gewohnten praktischen Trainings in Äthiopien. Die Neugeborenensterblichkeitsrate beträgt hier 5,8%. In Deutschland beträgt diese gerade einmal 0,3%. Da es aufgrund der Reisebeschränkungen und der allgemein unsicheren Lage in Äthiopien jedoch nicht möglich ist, Trainings vor Ort durchzuführen, wird hier bereits auf eine digitale Lösung zurückgegriffen.
Für eine gute digitale Alternative zu den praktischen Trainings vor Ort fehlen hier allerdings noch wichtige Aspekte, weshalb sich dazu entschlossen wurde, in Zusammenarbeit mit Amazon und Studenten der Hochschule München, eine neue digitale Lernplattform zu entwickeln.

Durch eine einfache und übersichtliche Benutzeroberfläche ist die Erstellung von interaktiven Lerneinheiten innerhalb weniger Minuten möglich. Mit *Alexandria* können vorhandene Videos, Texte, Fragebögen und Tests mit minimalem Aufwand kombiniert werden, auch innerhalb bereits fertig gestellter Kurse. Dieses Lernmaterial kann den Ärzten vor Ort dann ganz einfach zur Verfügung gestellt werden.
Hierdurch lässt sich der Arbeitsaufwand auf mehreren Schultern verteilen.

“Seit *Alexandria* bei unseren Kollegen und Kolleginnen in Jimma im Einsatz ist, merken wir hier in München eine deutliche Veränderung, wieviel wir an der Erstellung der Lernkurse selbst mitwirken. Früher haben wir noch die kompletten Einheiten selbst erstellt, jetzt werden viele Inhalte direkt in Jimma erstellt und wir geben nur noch manchmal Hilfestellungen. So können wir uns natürlich voll auf die inhaltlichen Aspekte konzentrieren.”
*- Arzt der LMU*

Dank der graphischen Oberfläche, in der die einzelnen Inhaltsblöcke genau in die gewünschte Anordnung gebracht werden können, und der Motivation unserer Kolleginnen und Kollegen in Äthiopien sind wir außerdem davon überzeugt, dass die Ärzte und Ärztinnen im *Jimma University Specialized Hospital* bald in der Lage sein werden, *Alexandria* ganz ohne fremde Hilfe  und möglicherweise auch in anderen Bereichen einzusetzen.
Eine Perspektive, wie sie ohne eine genau auf unser Problem zugeschnittene, digitale Lösung nicht möglich gewesen wäre.

“Since we use *Alexandria* to train our staff here in Jimma, we noticed a significant improvement in the confidence of everyone working here, when dealing with newborns having health issues. Since the learning platform makes it not only easy, but also super fast to create new courses, even our busy doctors can make up just enough time to do this.”
*- Arzt vor Ort in Äthiopien*

Die neusten Informationen zum Projekt erhalten sie über die Ankündigungen der Ludwig-Maximilians-Universität sowie der Hochschule München.

# 2 Description
By landing on our Website you will see the Login on the first page.
There are three diffrent categories of Persons that can login into the [Website](documents/Screenshots/Login_Website.png). Admin, Teacher and User.


User:

As User you can see the news on the [Hompage](documents/Screenshots/User_Homescreen.png).
On the top left side of the Page the user can click on his Account.
The User has a Username, Mail and Info that he is able to change it on this [Side](documents/Screenshots/User_Account.png).
He can also change his Password on this side.
On the Bottom he can also see the Courses on that he got invited. He can only leave the Course if he wants to but he cant join one.

On the Sidebar the User can get back to the Homepage by clicking on the Home button.
Below that he sees all of his Courses. He can either click on them to open the Course with all Chapters of the Course or he can hover over the Course Button on the [Sidebar](documents/Screenshots/User_Sidebar.png) to see a Shortcut of the Chapter in the Course.
By clicking on one of the [Chapter](documents/Screenshots/User_Chapters.png) he can test his Knowledge with the ChapterElements. A Chapter Element is either a Quiz, a [Text](documents/Screenshots/User_Text.png), a Video or Picture.


Teacher:

As teacher you can do at least everything that the user can do.
In the [Teacheraccount](documents/Screenshots/Teacher_Account.png) you can see all of your Courses. The Courses can be left by you, deleted, edited or you can create a new one.
Furthermore you can Add a User to one of your Courses.

As same as the user you have a [Sidebar](documents/Screenshots/Teacher_Sidebar.png) on the left but it has more Buttons.

First of all there is the [CourseManagement](documents/Screenshots/Teacher_Coursemanagement.png). The Teacher can see every Course of him. For every Course he can [edit](documents/Screenshots/Teacher_EditCourse.png), delete or create a new one. Depending on the teachers decision the Course can be hidden for all others if he deactivates the Visible-Button.

By Clicking on a Course on the Sidebar the Teacher gets to the Chapter. Inside the Chapter he can create new [ChapterElements](documents/Screenshots/Teacher_Chapter.png). Chapter Elements can be [Pictures](documents/Screenshots/Teacher_PictureEinfügen.png), [Quizzes](documents/Screenshots/Teacher_QuizErstellen.png), [Videos](documents/Screenshots/Teacher_CourseErstellen.png) or a [Text](documents/Screenshots/Teacher_Texterstellen.png).

The second new Button on the left is the Create Course [Button](documents/Screenshots/Teacher_CourseErstellen.png). It takes the Teacher directly to Side where he can create the Course by giving him a Coursename and choosing if he wants the Course to be visible. After that he can Add as many Chapters with Chapternames as he wants. He can also create or edit all Chapters of the new Course now.
By editing one of the Chapters he can create a new Text, Quiz, Picture or Video as ChapterElement of the Chapter like in the Paragraph before.

The third Button on the left is [UserManagement](documents/Screenshots/Teacher_UserManagement.png). By clicking on the Button the Teacher can select one of his Courses. Depending on the choice a new side opens where the Teacher can see all Users that are allowed to see the [Course](documents/Screenshots/Teacher_UserManagementOfSingleCourse.png). If the Teacher wants he can delete a Person in his Course by klicking on the red x. He can also add a User to a Course by entering the new UserId of the User that wants to be in the Course. 


Admin:

As Admin you can do at least everything that the user and the teacher can do appart from the UserManagement of the Teacher.
When the Admin clicks on his [UserManagement](documents/Screenshots/Admin_UserManagement.png) he can see all Users that exist on the [Website](documents/Screenshots/Admin_AdminCanSeeAllAcounts.png). He is the only one that can create a new User, Teacher or even another Admin [Account](documents/Screenshots/Admin_UserErstellung.png). By Editing an account he can see all informations of the Account.
Furthermore he is the only one able to delete Users.



# 3 Software architecture

The software is contains the frontend in the client part, the backend in the server part.
SEIIApp.Server.Test has no use, those tests might not work properly.
SEIIApp.Shared contains all the DTOs you need.

We don't use any special frameworks or anthing like it, the backend works properly as long as you don't change anything, due to the not perfect implementation of the database.

Now to the IMPORTANT stuff you need to know when you want to continue the development of the app:

We weren't able to implement cookies, therefore the [BiscuitService](src/SEIIApp/Client/Services/BiscuitService.cs) exists.
This just pretends to be a cookie, so pls replace this with something working, as for now this causes the page to crash during a reload.

The backend contains the UltimateChapterElementDefinitionDto, this is usefull to use the same endpoint for all ChapterElementTypes, pls dont use this in the frontend.

You should be able to start this by simply choosing SEIIApp.Server and start this run configuration, no further adjustments needed.

# 4 Team and contact
Our Team contains 6 Persons. Dominik and Julian were mainly responsible for the backend, while Markus, Max, Sophie and Felix worked mainly in the frontend. 
For Questions contact Markus at markus.kinast@hm.edu.

# 5 Attachments
To get a first insight into the application and general informations, all files that were created during the implementation are listed below:
* [Storyboard](documents/LMU_TEAM_G_STORYBOARD.pdf)
* [FAQ](documents/LMU_TEAM_G_FAQ.pdf)
* [PressRelease](documents/LMU_TEAM_G_PR.pdf)
