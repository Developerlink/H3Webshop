import React from "react";
import { ListGroup, ListGroupItem } from "reactstrap";

const ProductList = (props) => {
    console.log("Trying to populate my list");
  return (
    <ListGroup>
      {props.products.map((product) => (
        <ListGroupItem key={product.id} tag="button" action>{product.name}</ListGroupItem>
      ))}
    </ListGroup>
  );
};

export default ProductList;
