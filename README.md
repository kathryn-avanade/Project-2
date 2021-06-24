# Project-2


**Contents**
---------------
[Introduction](#Introduction)

[Brief](#Brief)

[My Idea](#MyIdea)

[Project Management](#ProjMan) 

[Version Control](#VC) 

[Architecture](#AppArch)

[Risk Assessment](#Risk)

[Testing](#Testing)

[Deployment](#Deployment) 

[Front-End Design](#FD)

[Known Issues](#Issues)

[Future Improvements](#Future)






<span id="Introduction"></span>
**Introduction**
---------------
Justification for moving into the cloud:
  * Updates can occur with no downtime for users or extra work for users; as will be demonstrated here
  * Availability & Reliability: Azure offers SLAs for expected performance of cloud resources so app will rarely go down. If they do there are features (azure service health) which can give information about any underperformance
  * Cost: Little to no cost to deploy the app, azure devops is free, azure resources are pay as you go so no upfront cost
  * Scalability: Relatively easy to create an infrastructure in the cloud which scales as the demand on your app grows
  * Future improvements: New features and tools of azure can be used to improve the app 

The tools used to solve the problem:
  * Ansible: Resource configuration management
  * Terraform: Infrastructure as code
  * Git: Software which manages code pushes/pulls, version control system
  * Github: Online remote repo for code 
  * Azure DevOps Boards: Used to create user stories, epics, tasks on Boards
  * Azure DevOps Pipelines: Push to master branch as a trigger to provide continuous integration
  * Visual Studio 2019: Local software writing app to push code from 

<span id="Brief"></span>
**Brief**
---------------

* To create 4 services which communicate with each other and a front end so that a user can interact with the app. 
* Two of these services will create a random object, the third service will combine these objects in some way, and the fourth will be the front end which renders the html so that the user can see this generated object.
* It is important to be able to make a change to the implementation and have this be deployed continuously such that the users experience is not affected.

<span id="MyIdea"></span>
**My Idea**
---------------

"Your dream wedding generator." 

The objects generated will be a person and a place. The objects will be generated randomly from an array of 10 objects which is hard-coded into services one and two. If I have enough time, the frontend could also produce a image to go along with the object, and store the result in a database that can be accessed via another webpage on the app.

The page will display the result "Your dream wedding is with [person] in [place]". 

<span id="ProjMan"></span>
**Project Management** 
---------------

Project Management 
* I have used Azure DevOps Boards for project management which you can find a link to here: 
[User Stories, Tasks and Epics](https://dev.azure.com/kathrynmcgregor/Project-2-Devops/)
* I have also kept a diary with details on what was done and when, in addition to this documentation. You can find this under the diary section.

CI Pipeline
* I aim to produce code on my local computer using Visual Studio 2019 and then push this to github in a feature branch. 
* Once the code is complete and tested, I will merge the feature branch with the master branch, (or just push a new change from VS2019) which will trigger the CI server (Azure Pipelines) to build and deploy to a cloud-based environment where the infrastructure is created in terraform.

![Diagram](/CIPipeline.png?raw=true)

* In practice, I was only able to run terraform locally. I also used Github Actions to deploy my code instead of azure devops. This was because I was already working a lot within github and found github actions more user-friendly than azure devops. 

![Diagram](/NewCIPipeline.png?raw=true)

<span id="VC"></span>
**Version Control** 
---------------

* For version control I used github/git. I am using the master branch for my documentation and up-to-date code that successfully builds. This branch also contains the github workflows (yml files) to make build jobs portable. 
* I used a new branch, 'feature-branch-1' to push my code to as I was working. I also created a new branch called 'testing' to try to rectify some of the problems I was having with testing.

<span id="AppArch"></span>
**Service Oriented Architecture**
---------------

![Diagram](/DesignNew.png?raw=true)

Service 1
The core service – this renders the HTML, it will also be responsible for communicating with the other 3 services, and finally for persisting some data in an SQL database if there is time to implement this.

Service 2 + 3
These will both generate a random “Object”, in my idea these objects will be a person and a place. If I have any extra time it would improve the application to have pictures associated with each of these things as well.

Service 4
This service will also create an “Object” however this “Object” must be based upon the results of service 2 + 3, in my case, the object will be the string: "Your dream wedding is with {serviceOneResponseCall} in {serviceTwoResponseCall}". This service will persist the data in a database if there is enough time.

<span id="Risk"></span>
**Risk Assessment**
---------------

|Risk|Likelihood|Severity|Control|Update
|---|---|---|---|---|
|Web server goes down|Low|High|Set up a backup virtual machine|Not implemented 
|Grammar of resulting sentence doesn't make sense|High|Low|Manually check the array entries to check they make sense|Altered the strings so that each result made sense 11/06/21
|Services cant comunicate with each other|Med|High|Test that routing is correct and that the app settings are correct|A check was done on the locally running code 11/06/21, tests haven't been written
|Build trigger fails|Med|High|Test that the pipeline is triggered by pushing new code to master branch, check that merge conflicts don't affect this process|To be updated
|Push fails|Med|High|Check before deployment that updates to the app get committed to github|Check that branch is correct and all commits are staged before pushing, VS2019 is a better way of doing this than git bash for me as I can visually see which folders and files are being staged more clearly|07/06/21
|Automated test report generation fails in pipeline|Med|Low|As a fail safe, generate a test report locally and save it|Saved report locally 16/06/21 then 21/06/21
|Images don't correspond with text|High|Med|Write a test to ensure the correct array index is chosen|Manually checked this worked but didnt write a test 16/06/21 |
|Github actions can't find access azure resources|Med|High|Happened with deployment the first time, solution was to just refresh all jobs, can also delete a resource and run terraform again|23/06/21
|Deployed resources can't be accessed from azure|High|High|Couldn't figure out the problem or solution|23/06/21

<span id="Testing"></span>
**Testing**
---------------

**Unit Tests**

* Unit tests using XUnit are written for all methods in all controllers in the application. This required mocking for the Ilogging, IConfiguration and database objects 
* To test the database objects using mocking I had to implement a repository pattern
* I used XUnit testing, ensuring I kept to best practises by keeping all tests associated with seperate controllers in serparate folders.
* These type of tests are to ensure controllers return the desired result
* To test the app further would require integration, functional and load/stress testing, as unit testing isolates the part of your code from it's dependancies and infrastructure. 

**Results**

* Results of tests are logged in the test coverage report below. To generate the report, I used "XPlat Code Coverage" and then generated a html report
* The files excluded from the test report are files with very minimal functionality e.g. the error view method in the home controller was auto generated when an mvc project is created, interfaces don't contain functionality, migration files, program and startup files.

![Diagram](/testreport.png?raw=true)
![Diagram](/testreport2.png?raw=true)

<span id="Deployment"></span>
**Deployment**
---------------

**What I wanted to do:**

The applications services will be deployed using Azure as a cloud platform but the app can be deployed using any appropriate Azure services, a list of possibilities include:
* Azure app service
* Azure functions
* Self managed VMs
* VM scale set with loadbalancers 

There should be four steps to the deployment pipeline (done in azure devops or github actions):
* Infrastructure (terraform locally or within a pipeline)
* Build
* Test
* Deploy

I used an Azure app service for the frontend service, and 3 azure functions for my other services. I also needed an azure database for mysql. I created these using terraform locally.
 
**Why I wanted to do it this way**
* I wanted to use azure functions because they are scalable and lightweight. 
* I wanted to use azure devops because it has my user stories already within it. It is also a microsoft product so I thought it would give me practise and experience which would be more useful to me as part of a microsoft based company.

**Why I had to change my plan**
* I found azure devops not very user friendly and it also required a build agent that I created and configured in azure which was an extra step that wasn't required using github actions. 
* Although a benefit of using Azure Devops is that it is consistently improving, I actually found that this meant it was hard to troubleshoot problems and ask for help when the GUI I was using was different than expected after looking at articles.

**What I actually did**
* After having problems with azure devops and function apps, I decided to run a simpler terraform script which created all app services and a database, this was quicker to write, debug and run.
* I used github actions instead to deploy the app, as I had problems with azure devops.

**Result**
* After many unsuccessful attempts I managed to deploy all services using github Actions 
* However something, somewhere is wrong as only service 1-3 appear when the azure resource is accessed 
* It also meant I had to change some of my code for the app settings, which meant some of my tests failed
* In the interest of time I commented these failing tests out and continued with trying to deploy the app, but now the code coverage for my deployed app isn't as high 
* Unfortunately this means I can't show you the full continuous integration 
* I will now show the result in azure 

![Diagram](/deploy.png?raw=true)
![Diagram](/deployed.png?raw=true)
![Diagram](/deployed2.png?raw=true)
![Diagram](/deployed3.png?raw=true)

<span id="FD"></span>
**Front-End Design**
---------------

I will now give a demo of my app locally so you can see the frontend and database section of the app.

![Diagram](/frontend.png?raw=true)
![Diagram](/weddings.png?raw=true)

<span id="Issues"></span>
**Known Issues**
---------------

* Something is wrong with the deployment of the app which needs to be fixed 
* My frontend images overlap with the footer when the window size is adjusted 



<span id="Future"></span>
**Future Improvements**
---------------

* It would be nice to get some user input, like a name/handle to store in the weddings list to see who got a match. 
* It could also be useful to have a delete option on the wedding list 
* I could also incorporate terraform into github actions yaml file
* I could use app functions instead of app services


