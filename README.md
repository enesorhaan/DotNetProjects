<h1>DotNet Projects</h1>

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

<h2>H2 Solution</h2>


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

<h4>API Enpoint</h4>

- To get a specific book by ID: `GET /api/books/getbyid/{id}`

<p>
   In the screenshot below, according to the request created with the above API Endpoint by giving the wrong ID in the GetBooks process with the Specific ID; There is a Status Code returned in the response and a Validation Failed error returned in the response body.
</p>


![image](https://github.com/enesorhaan/DotNetProjects/assets/59869028/a65309e4-36e4-4ccb-97bd-da54dc250d69)




