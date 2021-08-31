import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import { Route } from 'react-router';
import Home from './Home';
import Products from './Product/Products';
import Employees from './Employee/Employees';

class Layout extends Component {
    static displayName = Layout.name;

    render() {
        return (
            <div>
                <NavMenu />
                <Container>
                    <Route exact path='/' component={Home} />
                    <Route path='/products' component={Products} />
                    <Route path='/employees' component={Employees} />
                </Container>
            </div>
        );
    }
}

export { Layout };
