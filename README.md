# RealChem









GILLIAN HUGHES
SENIOR PROJECT PROPOSAL
REALCHEM

Section: CSC498 A
September 14, 2020











Table of Contents
Project Summary	2
Significance	3
Required Tools & Availability	3
Demonstration Plans	4
Qualifications	4
Project Specifications	5
Motivation & Goals	5
Functional Specifications	5
User Interface Specification	6
Technical Details	6
Timeline	6
Checkpoint #1 (September 28th)	6
Checkpoint #2 (October 12th)	7
Checkpoint #3 (October 26th)	7
Checkpoint #4 (November 30th):	7
Future Enhancements	8
Bibliography	8



Project Summary

RealChem is a mobile application that is designed to assist chemistry students at the high school and collegiate levels. It is intended to make chemistry 
interactive and visual, to help students overcome the fear that chemistry poses to many. Through an augmented reality app, students will be able to piece 
together molecules on their desk, in their dorm room, or on the go. This application, created using Unity, will bring theoretical concepts of chemistry to life. 
It will enable users to piece together molecules using common organic elements and the fundamental rules of chemistry. This will promote a deeper understanding 
of the way organic molecules interact by allowing users to visualize--on a large scale--molecular interactions that are fundamental to life. 

Significance
Motivation & Goals

College students all over the country dread the semester they must take organic chemistry. Horror stories are passed down. Online forums are petrifying. 
Walking into the classroom day one is enough to cause any student to consider a major change. Three years ago, I was that student. Shortly after that day, 
I discovered my love for chemistry. I fell in love with atoms, elements, and molecules, and all the complex interactions between these miniscule entities. 
My goal for this project is to help other students fall in love with chemistry: to remove the stereotype surrounding the subject and replace it with curiosity 
and fascination. My application will allow students to create and interact with organic chemistry molecules. By compelling users to piece different organic 
elements together to form a molecule, it will facilitate the learning of bond rules. Then, students can place their molecule into the world around them and 
interact with it, allowing them to see all sides of a molecule, learn stereochemistry, and observe the way elements interact with one another. 

This project will require the fusion of multiple areas of computer science. It will require Artificial Intelligence/Machine Learning knowledge to teach the 
computer bonding rules, knowledge of mobile application development, and knowledge of graphics to create the visual aspects. The scope of this project involves
material I’ve learned through courses taught at DePauw and internship experiences. I will need to create a mobile application with an appealing user interface,
teach the program objects how to interact with the user’s environment, and teach the program chemistry rules.
Required Tools & Availability

This project will require access to a Windows computer, Unity, Android Build Support, GitHub, and C#. I am using my personal Windows laptop for this project, 
and I will be programming in Visual Studio Code (version 1.48.2). I will use GitHub to save and track progress of my application. Unity contains an android 
support plugin, allows me to create 3-D meshes of objects, and is the engine I will use to render my application. Unity also allows you to access Google’s AR 
Core through Unity’s AR Foundation, which will allow me to use any features I may need.
Demonstration Plans

I will demonstrate RealChem virtually, by sharing my screen in a zoom call. To ensure that everything works properly, I will practice my demonstration the day 
before by calling a friend on zoom. If there are any technical difficulties while presenting, I will revert to my backup plan of sending a previously made screen
recording to my professor.  
Qualifications

I have taken several chemistry classes, which have provided me with the necessary knowledge to write the laws of chemistry into a computer application. In the 
summer of 2019, my internship project involved creating a program that connected a molecule generating program to a molecule evaluation program. Thus, I already 
have significant experience with computer programs that involve chemistry. Two summers ago, I worked at a technology summer camp, where I shadowed a class that taught
kids how to make a VR game using Unity. C# is the language that is compatible with Unity, so this experience also taught me that language. In addition to that 
summer-long experience, a lot of my Unity knowledge comes from watching tutorials and following along on my personal computer. I have used Visual Studio Code as
my IDE of choice since this past summer’s internship.
Project Specifications

Functional Specifications

The application will present the user with the most common organic elements (H, C, O, N, P, Si, S). They can select from these elements to build their own molecule.
The program will know the bonding rules of chemistry and prevent the user from creating an invalid molecule. These rules will be programmed in a C# script, inside an 
element class, where each element’s legal number of bonds are included. Once the user has finished creating their molecule and the program has deemed it valid, the user 
can place this molecule into their environment where, using augmented reality technology, it can be manipulated. The user can move it around, rotate it, and zoom in and out. 

User Interface Specification

The user interface will be created inside Unity. Unity has UI components that can be added to your application and controlled with C# scripts. Upon opening the 
application, the user will be greeted by a window containing instructions. The user interface will include a drawer icon. When pressed, the drawer opens. A drawer
is a standard UI element that contains entities (in my case, element buttons), that, when clicked, are added to the user’s environment. An example of a drawer is the
“emoji keyboard.” When opened, this drawer contains many icons that the user can click on to add to their message. Similarly, my drawer will contain all the organic 
elements available to be used in the application. The user can drag and drop elements into the world. If the user drags elements close together, they will bond. The 
user can also drag and drop atom into a trashcan. Once a valid molecule is formed (one or more bonds between two or more elements), an information icon will appear.
If the user clicks the icon, it will redirect them to a website to read more about the molecule. I will use open source jpegs for my icons. I will distribute my finished 
application to peers as an APK, and ask for brief feedback as to what could be improved.
Technical Details

RealChem will use Google’s AR Core through Unity, using Unity’s AR Foundation. This will allow me to use any features I may need, for example: plane tracking, 
light estimation, and device tracking. An advantage of this is that I do not have to use a third-party library—I’m using the native solution for Android AR through unity. 
This makes my application “future-proof”. Additionally, I can use all of Unity’s 3-D capabilities. 
Timeline

Checkpoint #1 (September 28th)
•	I will develop a basic prototype. Basic functionality will include: 
o	User can drag and drop atoms on the screen
o	I will hard code 3 elements (H, C, O) that can be combined to create 3 possible molecules- H2O, CO2, C2H4
o	I will show the basic structure of the application’s interface (Element Drawer, Trash Can, Drag and Drop feature) and its functionality
•	I will test exportation to Android, recording my results and displaying these on demo day, along with an APK that can be downloaded
Checkpoint #2 (October 12th)
•	I will demonstrate a functional 3- D application
•	I will expand the prototype to contain all possible atoms, demonstrating these by opening the app drawer
•	I will implement the bonding rules (no charged molecules allowed) and remove the hard-coded elements
•	My system will be able to detect what elements the user placed together, and create a 3-D model of the molecule
Checkpoint #3 (October 26th)
•	I will implement full AR Integration and make the User Interface work with AR 
•	I will implement the information tab, showing my application redirecting the user to the corresponding molecule page on ChemSpider.com
Checkpoint #4 (November 30th):
•	I will polish my application by:
o	I will fix any bugs, demonstrating this by screenshotting the bug and then showing the resulting fix
o	I will polish the UI, adding the instructional window, improving icons, and 
o	I will show the app icon for RealChem and the finalized user interface
•	I will build the app, distribute it to peers and friends as an APK, and receive their feedback for improvements.
Future Enhancements


•	Currently, CHEM is only an android application, but in the future, I would like to extend it to IOS devices.
•	In the future, I would like to provide a library of common organic molecules that the user can place in their environment and manipulate.
•	In the future, I would either like to extend this application, or make a sister application that is tailored toward scientists in the healthcare industry. 
I think an molecule visualization app that allows them to act with and create large scale molecules will help them discover new drugs.
Bibliography

Antkowiak, Tomek. “Create your first AR application with Unity and Vuforia.” ITgenerator, n.d. Web. 14. Sept. 2020. <https://www.itgenerator.com/augmented-reality-app-development/>
“AR Foundation.” Unity, n.d. Web. 14. Sept. 2020. <https://unity.com/unity/features/arfoundation>
Buckley, Daniel. “How to Create an Augmented Reality App in Unity.” Zenva. N.p., 25 Sept. 2019. Web. 14 Sept. 2020. https://vrgamedevelopment.pro/how-to-create-an-augmented-reality-app-in-unity/
“Creating AR apps in Unity: the latest tips and resources.” Unity, n.d. Web. 14. Sept. 2020. <https://unity3d.com/how-to/create-AR-games-in-Unity-efficiently>
Greene, Jacob. “Creating Mobile Augmented Reality Experiences in Unity.” The Programming Historian. < https://programminghistorian.org/en/lessons/creating-mobile-augmented-reality-experiences-in-unity>
“Organic Chemistry.” College to Career. ACS, n.d. Web. 14. Sept. 2020. <https://www.acs.org/content/acs/en/careers/college-to-career/areas-of-chemistry/organic-chemistry.html>
“The Offical Guide to Unity.” Unity, n.d. Web. 14 Sept. 2020. < https://www.youtube.com/watch?v=aY https://www.youtube.com/watch?v=aYjft-zZxP4&list=PLX2vGYjWbI0Q1e0IIGsYro3SiE0chtRtcjft-zZxP4&list=PLX2vGYjWbI0Q1e0IIGsYro3SiE0chtRtc>

