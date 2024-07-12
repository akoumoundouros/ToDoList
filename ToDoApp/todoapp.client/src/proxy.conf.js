const { env } = require('process');

const target = `https://localhost:32774`;

const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/api/ToDoList/",
      "/api/ToDoList/**",
      "/api/ToDoItem*",
      "/api/ToDoItem/**",
      "/api/ToDoItem/"
    ],
    target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;
