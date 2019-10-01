/*eslint-disable*/
import React from "react";
// @material-ui/core components
import { makeStyles } from "@material-ui/core/styles";
import Hidden from "@material-ui/core/Hidden";
// core components
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Card from "components/Card/Card.js";
import Table from "components/Table/Table.js";
import TableBody from "@material-ui/core/TableBody";
import TableCell from "@material-ui/core/TableCell";
import TableHead from "@material-ui/core/TableHead";
import TableRow from "@material-ui/core/TableRow";
import CardHeader from "components/Card/CardHeader.js";
import CardBody from "components/Card/CardBody.js";
import CustomInput from "components/CustomInput/CustomInput.js";

import styles from "assets/jss/material-dashboard-react/views/iconsStyle.js";

const useStyles = makeStyles(styles);

export default function Icons() {
  const classes = useStyles();
  return (

    <GridContainer>
      <GridItem xs={12} sm={6} md={6} >
        <Card>
          <CardHeader plain color="primary">
            <h4 className={classes.cardTitleWhite}>Gestión de usuarios</h4>
          </CardHeader>
          <CardBody>
            <GridItem xs={12}>
              <Table
                tableHeaderColor="primary"
                tableHead={["Usuario", ""]}
                tableData={[
                  ["José González", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                  ["Arturo Campos", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                  ["Rodrigo Cortés", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                  ["Juan Gómez Jurado", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                  ["Cristina Alonso", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                  ["María Josefina de los Campos", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
                  ["DelfínTubes", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>]
                ]}
              />
            </GridItem>
          </CardBody>
        </Card>
      </GridItem>

      <GridItem xs={12} sm={6} md={6} >
        <Card>
          <CardHeader plain color="primary">
            <h4 className={classes.cardTitleWhite}>Grupos a los que pertenece</h4>
          </CardHeader>
          <CardBody>
            <GridItem xs={12}>
              <Table
                tableHeaderColor="primary"
                tableData={[
                  [<i className="material-icons" style={{ fontSize: '30px' }}>crop_square</i>, "Adminstración", <i className="material-icons" style={{ cursor: "pointer" }}>remove_red_eye</i>],
                  [<i className="material-icons" style={{ fontSize: '30px' }}>crop_square</i>, "Guardias de seguridad", <i className="material-icons" style={{ cursor: "pointer" }}>remove_red_eye</i>],
                  [<i className="material-icons" style={{ fontSize: '30px' }}>crop_square</i>, "Operarios", <i className="material-icons" style={{ cursor: "pointer" }}>remove_red_eye</i>],
                  [<i className="material-icons" style={{ fontSize: '30px' }}>crop_square</i>, "Maestros", <i className="material-icons" style={{ cursor: "pointer" }}>remove_red_eye</i>],
                  [<i className="material-icons" style={{ fontSize: '30px' }}>crop_square</i>, "Carretilleros", <i className="material-icons" style={{ cursor: "pointer" }}>remove_red_eye</i>]
                ]}
              />
            </GridItem>
          </CardBody>
        </Card>

      </GridItem>

      <Card>
        <CardHeader plain color="primary">
          <h4 className={classes.cardTitleWhite}>Datos del usuario</h4>
        </CardHeader>
        <GridItem >
          <CardBody>
            <GridItem xs={4}>
              <CustomInput
                labelText="Nombre"
                id="company-disabled"
                formControlProps={{
                  fullWidth: true
                }}
                inputProps={{
                  disabled: false
                }}
              />
            </GridItem>
            <GridItem xs={4}>
              <CustomInput
                labelText="Apellidos"
                id="0"
                formControlProps={{
                  fullWidth: true
                }}
                inputProps={{
                  disabled: false
                }}
              />
            </GridItem>
            <GridItem xs={4}>
              <CustomInput
                labelText="DNI"
                id="1"
                formControlProps={{
                  fullWidth: true
                }}
                inputProps={{
                  disabled: false
                }}
              />
            </GridItem>
            <GridItem xs={4}>
              <CustomInput
                labelText="Email"
                id="2"
                formControlProps={{
                  fullWidth: true
                }}
                inputProps={{
                  disabled: false
                }}
              />
            </GridItem>
          </CardBody>
        </GridItem>
      </Card>
      <GridItem xs={12} sm={12} md={12}>
        <div style={{ textAlign: 'right' }}>
          <br />
          <br />
          <br />
          <label style={{ fontSize: '30px', color: 'green' }}>Enviar Anuncio  </label>
          <i className="material-icons" style={{ fontSize: '50px', color: 'green', verticalAlign: 'top' }}>send</i>
        </div>
      </GridItem>
    </GridContainer>

  );
}
