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

# 3 Software architecture

The software is contains the frontend in the client part, the backend in the server part.
SEIIApp.Server.Test has no use, those tests might not work properly.
SEIIApp.Shared contains all the DTOs you need.

We don't use any special frameworks or anthing like it, the backend works properly as long as you don't change anything, due to the not perfect implementation of the database.

Now to the IMPORTANT stuff you need to know when you want to continue the development of the app:

We weren't able to implement cookies, therefore the [BiscuitService](src/SEIIApp\Client\Services\BiscuitService.cs) exists.
This just pretends to be a cookie, so pls replace this with something working, as for now this causes the page to crash during a reload.

The backend contains the UltimateChapterElementDefinitionDto, this is usefull to use the same endpoint for all ChapterElementTypes, pls dont use this in the frontend.

You should be able to start this by simply choosing SEIIApp.Server and start this run configuration, no further adjustments needed.

# 4 Team and contact
Our Team contains 6 Persons. Dominik and Julian were mainly responsible for the backend, while Markus, Max, Sophie and Felix worked mainly in the frontend. 
For Questions contact Markus at markus.kinast@hm.edu.

# 5 Attachments
