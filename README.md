# WebPetApp
WebPetApplication
TASKS FROM Application Assignment 

// GET api/PetsOwner/{petownerId}/Pets
returns List of Pets by Owner Id in json fromat STATUS:200 OK

// GET api/PetsOwner/{petownerId}/Approves/{petwalkerId}
returns true if PetOwner(petownerId) approves PetWalker(petwalkerId) or false if does not approve STATUS:200 OK

GET api/Pets/{petid}
returns Pet By id in json fromat STATUS:200 OK

// POST api/Pets
Creates new pet.You must POST in Json Format the new pet info(Name,DateOfBirth,PetOwnerId) and returns STATUS:201 and new created Pet in Json Format i.e
{
"Name":"Lucy",
"DateOfBirth":"2014-12-15 00:00:00.000",
"PetOwnerId":20
}

// PUT api/Pets/{petid}
UPDATE pet with given id (You must give in json format all info of pet to update (Id,Name,DateOfBirth,PetOwnerId) and returns STATUS:204 NoContent i.e 
{
"Id": 27,
"Name":"Rodo",
"DateOfBirth":"2014-04-03 00:00:00.000",
"PetOwnerId":21
}

GET api/Pets/Age/{age:int}
returns Pets under given age(integer) in json fromat STATUS:200 OK

ADDITIONAL TASKS THAT Assignment can do

GET api/Pets
return all Pets in json fromat STATUS:200 OK

GET api/Pets/PetOwner/
return all Pets with details of their owner

// DELETE api/Pets/{petid}
Deletes pet with specified id and returns STATUS:200 OK and deleted Pet in Json Format

// GET api/PetsOwner
returns all PetOwners in json fromat STATUS:200 OK

// GET api/PetsOwner/{petownerid}
returns PetOwner By id in json fromat STATUS:200 OK

// PUT api/PetsOwner/{petownerid}
UPDATE petowner with given id (You must give in json format all info of petowner to update (Id,FirstName,LastName,Email) and returns STATUS:204 NoContent i.e 
 {
    "Id": 19,
    "FirstName": "George",
    "LastName": "Harper",
    "Email": "g.harp@Petlover.com"
  }

// POST api/PetsOwner
Creates new PetOwner.You must POST in Json Format the new PetOwner info(Name,DateOfBirth,PetOwnerId) and returns STATUS:201 and new created PetOwner in Json Format i.e
{
"FirstName":"Andreas",
"LastName":"Kili",
"Email":"a.kil@petlover"
}

// DELETE api/PetsOwner/{petownerId}
Deletes PetOwner with specified id and returns STATUS:200 OK and deleted PetOwner in Json Format

// GET api/PetWalker
return all PetWalkers in json fromat STATUS:200 OK

// GET api/PetWalker/{petwalkerid}
returns PetWalker By id in json fromat STATUS:200 OK

// PUT api/PetWalker/{petwalkerid}
UPDATE PetWalker with given id (You must give in json format all info of PetWalker to update (Id,FirstName,LastName,Email,PhoneNumber) and returns STATUS:204 NoContent i.e 
  {
    "Id": 19,
    "FirstName": "Panagiota",
    "LastName": "Mountz",
    "Email": "p.mou@Petlover.com",
    "PhoneNumber": "6989898989"
  }
  
// POST api/PetWalker
Creates new PetWalker.You must POST in Json Format the new PetWalker info(FirstName,LastName,Email,PhoneNumber) and returns STATUS:201 and new created PetWalker in Json Format i.e
{
"FirstName":"Xara",
"LastName":"Joe",
"Email":"x.joe@petlover",
"PhoneNumber": "6984498977"
}

// DELETE api/PetWalker/{petwalkerid}
Deletes PetWalker with specified id and returns STATUS:200 OK and deleted PetWalker in Json Format
