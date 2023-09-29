<h1>DotNet Projects</h1>

<h2>H8_MovieStore</h2>

<p>
  In this solution, Movie Store API was created and the following technologies were used.
</p>

1. Used ViewModel and Dto using **CQRS** principle. Objects were transformed into each other with the Automapper library.
2. All validations were created with the **FluentValidation** library.
3. Exception and Logging infrastructure is written with custom **Middleware**.
4. Dependency within the project is minimized. Dependencies were managed from a single point by using DI Container and **Dependency Injection** at necessary points.
5. A basic level Authentication and Authorization structure was implemented in the project with **JwtBearer**. Endpoints are authorized only by the Customer Endpoint.
6. The tests of the project were written with **Unit Test**.

<h3>CRUD Operations with Postman</h3>

This section shows CRUD operations for any data in the API (movies, directors, etc.) using Postman.

**1. First of all, in order to access any data, a customer record must first be created.**
- API Customer Endpoint:  `POST /customers`
- Sample Json Format that should be included in the body of the request to be sent:

```json
{
  "name": "Enes",
  "surName": "Orhan",
  "email": "enesorhan@hotmail.com",
  "password": "12345"
}
```

**2. AccessToken is created with the created customer record.**
- Endpoint to use to create AccessToken: `POST /customers/connect/token`
- Sample Json Format to be sent to provide Authentication with Endpoint:

```json
{
  "email": "enesorhan@hotmail.com",
  "password": "12345"
}
```

- Sample Json format in the body as response:
```json
{
    "accesToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYmYiOjE2OTU5NDQ2NjgsImV4cCI6MTY5NTk0NTU2OCwiaXNzIjoid3d3LnRlc3QuY29tIiwiYXVkIjoid3d3LnRlc3QuY29tIn0.vBZoAtujJmC8qEpQJEDlg7b14DZJJIex6jlZhL5iCD4",
    "expiration": "2023-09-29T02:59:28.4987901+03:00",
    "refreshToken": "0cea5f70-a04a-48df-9b35-663eb36af511"
}
```

3. The AccessToken obtained in the Response Body is added as a Bearer Token in the Authorization section of the request to be used in CRUD operations.
   Endpoints of CRUD operations of Actors are as follows.
- To list all actors  : `GET /actors`
- To add a new actor  : `POST /actors`
- To update a actor   : `PUT /actors/{id}`
- To delete a actor   : `DELETE /actors/{id}`

<h2>H1_RestfulApi</h2>
<p>
  This project provides a RESTful API that can be used to perform basic operations such as adding, updating, listing and deleting products. <br/>
  It also includes the ability to list and sort products. <br/>
  Below are the API endpoints and screenshot.
</p>

<h4>API Endpoints</h4>

- To list all books:  `GET /api/books/getbooks`
- To filter and sort books by name: `GET /api/Books/GetBookName?name={name}`
- To get a specific book by ID: `GET /api/books/getbyid/{id}`
- To add a new book: `POST /api/books/createbook`
- To update a book: `PUT /api/books/updatebook/{id}`
- To delete a book: `DELETE /api/books/deletebook?id={id}`

![image](https://github.com/enesorhaan/DotNetProjects/assets/59869028/9ffd4561-4fee-40d8-a80f-1169e5cdcfe5)

<h2>H2_DIandMiddleware</h2>
<p>
  In this solution, custom middleware and Dependency Injection were created for the solution in <a href="https://github.com/enesorhaan/DotNetProjects/tree/main/H1_RestfulApi">H1_RestfulApi</a>
  Below are the API endpoints and screenshot of the output in the Console for Dependency Injection and the incoming Request. <br/>
  Additionally, Extension Method was used for Singleton.
</p>

<h4>API Endpoints</h4>

- To list all books:  `GET /api/books/getbooks`
- To filter and sort books by name: `GET /api/Books/GetBookName?name={name}`
- To get a specific book by ID: `GET /api/books/getbyid/{id}`
- To add a new book: `POST /api/books/createbook`
- To update a book: `PUT /api/books/updatebook/{id}`
- To delete a book: `DELETE /api/books/deletebook?id={id}`

![image](https://github.com/enesorhaan/DotNetProjects/assets/59869028/244bbeb3-877b-4b75-8aa1-f3ec80a3e1cb)


<h2>H3_ModelUsing/BookStore</h2>
<p>
  In this solution, it is aimed to make the code cleaner by using ViewModel and Model concepts. <br/>
  This project provides a RESTful API that can be used to perform basic operations such as adding, updating, listing and deleting books (CRUD). <br/>
  Below are the API endpoints and screenshot.
</p>

<h4>API Endpoints</h4>

- To list all books:  `GET /api/books/getbooks`
- To get a specific book by ID: `GET /api/books/getbyid/{id}`
- To add a new book: `POST /api/books/createbook`
- To update a book: `PUT /api/books/updatebook/{id}`
- To delete a book: `DELETE /api/books/deletebook/{id}`

![image](https://github.com/enesorhaan/DotNetProjects/assets/59869028/615bd2db-04c7-4a2c-a2d2-0b0acf4adc0c)

<h2>H4_FluentValidation</h2>
<p>
  In this solution, Fluent Validation has been applied to the Models in <a href = "https://github.com/enesorhaan/DotNetProjects/tree/main/H3_ModelUsing/BookStore">H3_ModelUsing/BookStore</a>
</p>

<h4>API Endpoint</h4>

- To get a specific book by ID: `GET /books/{id}`

<p>
   In the screenshot below, according to the request created with the above API Endpoint by giving the wrong ID in the GetBooks process with the Specific ID; There is a Status Code returned in the response and a Validation Failed error returned in the response body.
</p>


![image](https://github.com/enesorhaan/DotNetProjects/assets/59869028/a65309e4-36e4-4ccb-97bd-da54dc250d69)

<h2>H5_GenreController</h2>
<p>
  In this solution, entity, controllers, various validation and mapper operations belonging to the Book Genre for the project in <a href="https://github.com/enesorhaan/DotNetProjects/tree/main/H4_FluentValidation/BookStore">H4_FluentValidation</a> were created. <br/>
  Below are the API endpoints and screenshot.
</p>

<h4>API Endpoints</h4>

- To list all genres:  `GET /genres`
- To get a specific genre by ID: `GET /genres/{id}`
- To add a new genre: `POST /genres`
- To update a genre: `PUT /genres/{id}`
- To delete a genre: `DELETE /genres/{id}`

![image](https://github.com/enesorhaan/DotNetProjects/assets/59869028/f76ce3b0-0539-4277-9db8-07a3dbea2fdb)

<h2>H6_AuthorController</h2>
<p>
  In this solution, entity, controllers, various validation and mapper operations belonging to the Book Author for the project in <a href="https://github.com/enesorhaan/DotNetProjects/tree/main/H5_GenreController/BookStore">H5_GenreController</a> were created. <br/>
  Below are the API endpoints and screenshot.
</p>

<h4>API Endpoints</h4>

- To list all authors:  `GET /authors`
- To get a specific author by ID: `GET /authors/{id}`
- To add a new author: `POST /authors`
- To update a author: `PUT /authors/{id}`
- To delete a author: `DELETE /authors/{id}`

![image](https://github.com/enesorhaan/DotNetProjects/assets/59869028/5217f2cb-451d-468c-8171-84ea19f35cba)


<h2>H7_UnitTest</h2>
<p>
  In this solution, Unit Tests were written for the BookStore project in <a href="https://github.com/enesorhaan/DotNetProjects/tree/main/H6_AuthorController/BookStore">H6_AuthorController</a>. <br/>
</p>

<h3><a href="https://en.wikipedia.org/wiki/Unit_testing">What is Unit Test?</a></h3>

> Unit testing is a software development process in which the smallest testable parts of an application,
> called units, are individually scrutinized for proper operation.

The file structure created according to commands and requests has been preserved, and a Unit Test has been written for each method used. <br/>
__.NET Core Test Explorer__ Extension was used to view and test the tests together. The file structure and extension content are below.

![image](https://github.com/enesorhaan/DotNetProjects/assets/59869028/37207e40-9a52-479f-878f-96a7802a66c1)


