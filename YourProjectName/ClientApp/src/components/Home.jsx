import React from "react";
import { useState, useEffect } from "react";
import axios from "axios";
export default function Home() {
  const [books, setBooks] = useState([]);

  const fetchBooks = async () => {
    axios.get("/api/books").then(function (response) {
      const books = response.data;
      setBooks(books);
    });
  };

  useEffect(() => {
    fetchBooks();
  }, []);

  return (
    <div>
      {books.map((book) => {
        <div>{book}</div>;
      })}
    </div>
  );
}
