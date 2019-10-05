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
import Search from "@material-ui/icons/Search";

import styles from "assets/jss/material-dashboard-react/views/iconsStyle.js";
import Button from "components/CustomButtons/Button.js";

const useStyles = makeStyles(styles);

export default function Icons() {
  const classes = useStyles();
  return (
    <GridContainer>

      <GridContainer xs={4}>

        <GridItem>
          <Card>
            <CardHeader plain color="primary">
              <h4 className={classes.cardTitleWhite}>Gestión de usuarios</h4>
            </CardHeader>
            <CardBody>
             
              <GridItem>
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
                    ["DelfínTubes", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],  ["José González", <i className="material-icons" style={{ cursor: "pointer" }}>create</i>],
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

      </GridContainer>

      <GridContainer xs={8} style={{height:"120px", marginLeft: "-130px"}}>
        <GridItem xs={12} style={{marginLeft:"-15px"}}>
          <Card style={{width:"1041px"}}>
            <CardHeader plain color="primary">
              <h4 className={classes.cardTitleWhite}>Datos del usuario</h4>
            </CardHeader>
            <GridContainer>
              <GridItem>
                <CardBody>
                  <GridItem>
                    <CustomInput xs={6}
                      labelText="Nombre"
                      id="company-disabled"
                      formControlProps={{
                      }}
                      inputProps={{
                        disabled: false
                      }}
                    />
                    <CustomInput xs={6}
                      labelText="Apellidos"
                      id="0"
                      formControlProps={{
                      }}
                      inputProps={{
                        disabled: false
                      }}
                    />
                  </GridItem>
                  <GridItem style={{ paddingRight: "50px" }}>
                    <CustomInput
                      labelText="DNI"
                      id="1"
                      formControlProps={{
                      }}
                      inputProps={{
                        disabled: false
                      }}
                    />
                    <CustomInput
                      labelText="Email"
                      id="2"
                      formControlProps={{
                      }}
                      inputProps={{
                        disabled: false
                      }}
                    />
                  </GridItem>
                </CardBody>
              </GridItem>
            </GridContainer>
          </Card>
        </GridItem>
      </GridContainer>

      <GridContainer xs={4}>
      </GridContainer>

      <GridContainer xs={8} style={{marginTop:"-650px",marginLeft:"401px"}}>
        <Card>
          <CardHeader plain color="primary">
            <h4 className={classes.cardTitleWhite}>Grupos a los que pertenece</h4>
          </CardHeader>
          <CardBody>
            <GridContainer>
              <GridItem xs={12}>
                <Table
                  tableHeaderColor="primary"
                  tableData={[
                    [<i className="material-icons" style={{ fontSize: '30px', color: "green" }}>check_box</i>, "Adminstración", <i className="material-icons" style={{ cursor: "pointer" }}>visibility</i>],
                    [<i className="material-icons" style={{ fontSize: '30px', color: "green" }}>check_box</i>, "Guardias de seguridad", <i className="material-icons" style={{ cursor: "pointer" }}>visibility</i>],
                    [<i className="material-icons" style={{ fontSize: '30px' }}>crop_square</i>, "Operarios", <i className="material-icons" style={{ cursor: "pointer" }}>visibility_off</i>],
                    [<i className="material-icons" style={{ fontSize: '30px', color: "green" }}>check_box</i>, "Maestros", <i className="material-icons" style={{ cursor: "pointer" }}>visibility</i>],
                    [<i className="material-icons" style={{ fontSize: '30px' }}>crop_square</i>, "Carretilleros", <i className="material-icons" style={{ cursor: "pointer" }}>visibility_off</i>]
                  ]}
                />
                <GridContainer xs={12} style={{ paddingTop: "40px", paddingLeft: "190px"}}>
                  <GridContainer xs={3}>
                    <GridItem style={{ marginTop: "25px" }}>
                      <i className={"material-icons"} style={{ fontSize: "30px" }}>cached</i><label style={{ color: 'black', fontSize: "10px", verticalAlign: "super" }}>Resetear contraseña</label>
                    </GridItem>
                  </GridContainer>

                  <GridContainer xs={3}>
                    <GridItem style={{ marginTop: "25px" }}>
                      <i className={"material-icons"} style={{ fontSize: "30px" }}>delete_outline</i> <label style={{ color: 'black', fontSize: "10px", verticalAlign: "super" }}>Eliminar usuario</label>
                    </GridItem>
                  </GridContainer>

                  <GridContainer xs={3}>
                    <GridItem style={{ marginTop: "25px" }}>
                      <i className={"material-icons"} style={{ fontSize: "30px" }}>save</i><label style={{ color: 'black', fontSize: "10px", verticalAlign: "super" }}>Guardar cambios</label>
                    </GridItem>
                  </GridContainer>

                </GridContainer>
              </GridItem>
            </GridContainer>

          </CardBody>
        </Card>
      </GridContainer>
    
    </GridContainer>

  );
}