import React, { useEffect, useState } from "react";
import { Form, FormGroup, Label, Input, FormFeedback } from "reactstrap";
import styles from "./ProductForm.module.css";

const emptyProduct = {
  id: "",
  name: "",
  description: "",
  price: "",
  productType: {
    id: 1,
    name: "",
  },
};

const ProductForm = (props) => {
  const [product, setProduct] = useState(emptyProduct);
  const [nameIsInvalid, setNameIsInvalid] = useState(false);
  const [selectedOption, setSelectedOption] = useState(0);
  const [descriptionIsInvalid, setdescripTionIsInvalid] = useState(false);
  const [priceIsInvalid, setPriceIsInvalid] = useState(false);

  useEffect(() => {
    if (props.product) {
      console.log("props.product is set inside form");
      setProduct(props.product);
      setSelectedOption(props.product.productType.id);

      if (props.product.price < 0 || 100000 < props.product.price) {
        setPriceIsInvalid(true);
      } else {
        setPriceIsInvalid(false);
      }
      if (
        props.product.description.length < 0 ||
        2500 < props.product.description.length
      ) {
        setdescripTionIsInvalid(true);
      } else {
        setdescripTionIsInvalid(false);
      }
    } else {
      //console.log("props.product is NOT set!");
      setSelectedOption(0);
    }

  }, [props]);

  const onChangeHandler = async (event) => {
    const { name, value } = event.target;
    //console.log(value);

    if (name === "productType") {
      props.setProduct((prevValue) => {
        return {
          ...prevValue,
          [name]: { id: value, name: "" },
        };
      });
      setSelectedOption(value);
    } else {
      if (name === "price") {
        if (value < 0 || 100000 < value) {
          setPriceIsInvalid(true);
        } else {
          setPriceIsInvalid(false);
        }
      }
      if (name === "name") {
        if (value.length < 1 || 100 < value.length) {
          setNameIsInvalid(true);
        } else {
          setNameIsInvalid(false);
        }
      }
      if (name === "description") {
        if (value.length < 0 || 2500 < value.length) {
          setdescripTionIsInvalid(true);
        } else {
          setdescripTionIsInvalid(false);
        }
      }

      props.setProduct((prevValue) => {
        return {
          ...prevValue,
          [name]: value,
        };
      });
    }
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
            invalid={nameIsInvalid}
          />
          <FormFeedback>
            The name cannot be empty or more than 100 characters
          </FormFeedback>
        </FormGroup>
        <FormGroup>
          <Label>Select Product Type</Label>
          <Input
            type="select"
            name="productType"
            value={selectedOption}
            onChange={onChangeHandler}
          >
            {props.productTypes.map((productType) => (
              <option
                onClick={onChangeHandler}
                key={productType.id}
                value={productType.id}
              >
                {productType.name}
              </option>
            ))}
          </Input>
        </FormGroup>
        <FormGroup>
          <Label>Decription</Label>
          <Input
            className={styles.listGroup}
            type="textarea"
            name="description"
            id="description"
            value={product.description}
            onChange={onChangeHandler}
            invalid={descriptionIsInvalid}
          />
          <FormFeedback>
            The description cannot be more than 2500 characters
          </FormFeedback>
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
            value={product.price}
            onChange={onChangeHandler}
            invalid={priceIsInvalid}
          />
          <FormFeedback>
            The price amount must be valid (0-100.000)
          </FormFeedback>
        </FormGroup>
      </Form>
    </React.Fragment>
  );
};

export default ProductForm;
