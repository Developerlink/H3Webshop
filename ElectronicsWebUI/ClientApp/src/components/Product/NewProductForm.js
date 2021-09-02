import React, { useState } from "react";
import { Button, Form, FormGroup, Label, Input } from "reactstrap";

const newProduct = {
  id: "",
  name: "",
  description: "",
  price: "",
  productType: {
    id: "",
    name: "",
  },
};

const NewProductForm = (props) => {
  const [product, setProduct] = useState(newProduct);

  const onChangeHandler = (event) => {
    const { name, value } = event.target;

    console.log(value);

    setProduct((prevValue) => {
      return {
        ...prevValue,
        [name]: value,
      };
    });

    console.log(product);
  };

  const saveHandler = () => {
    props.onSubmit();
  };

  return (
    <React.Fragment>
      <Form>
        <FormGroup>
          <Label>Name</Label>
          <Input
            type="text"
            name="name"
            id="name"
            placeholder="product name"
            value={product.name}
            onChange={onChangeHandler}
          />
        </FormGroup>
        <FormGroup>
          <Label>Select Product Type</Label>
          <Input type="select" name="select" id="exampleSelect">
            <option>1</option>
            <option>2</option>
            <option>3</option>
            <option>4</option>
            <option>5</option>
          </Input>
        </FormGroup>
        <FormGroup>
          <Label>Decription</Label>
          <Input
            type="textarea"
            name="description"
            id="description"
            value={product.name}
            onChange={onChangeHandler}
          />
        </FormGroup>
        <FormGroup>
          <Label>Price</Label>
          <Input
            type="number"
            name="price"
            id="price"
            placeholder="amount"
            step="1"
            min={0}
            max={100000}
            value={product.name}
            onChange={onChangeHandler}
          />
        </FormGroup>
      </Form>
      <Button onClick={saveHandler} color="success">
        Save
      </Button>
    </React.Fragment>
  );
};

export default NewProductForm;
