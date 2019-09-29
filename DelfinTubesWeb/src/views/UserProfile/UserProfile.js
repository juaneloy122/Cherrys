import React from "react";
// @material-ui/core components
import { makeStyles } from "@material-ui/core/styles";
import InputLabel from "@material-ui/core/InputLabel";
// core components
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import CustomInput from "components/CustomInput/CustomInput.js";
import Button from "components/CustomButtons/Button.js";
import Card from "components/Card/Card.js";
import CardHeader from "components/Card/CardHeader.js";
import CardAvatar from "components/Card/CardAvatar.js";
import CardBody from "components/Card/CardBody.js";
import CardFooter from "components/Card/CardFooter.js";
import styles from "assets/jss/material-dashboard-react/views/dashboardStyle.js";
import avatar from "assets/img/faces/marc.jpg";
import { fontWeight } from "@material-ui/system";
{/* 
const styles = {
  cardCategoryWhite: {
    color: "rgba(255,255,255,.62)",
    margin: "0",
    fontSize: "14px",
    marginTop: "0",
    marginBottom: "0"
  },
  cardTitleWhite: {
    color: "#FFFFFF",
    marginTop: "0px",
    minHeight: "auto",
    fontWeight: "300",
    fontFamily: "'Roboto', 'Helvetica', 'Arial', sans-serif",
    marginBottom: "3px",
    textDecoration: "none"
  }
};

 */}

const useStyles = makeStyles(styles);

export default function UserProfile() {
  const classes = useStyles();
  return (
    <div>
      <GridContainer >


        <GridItem xs={12} sm={12} md={12} >
          <Card className={classes.tarjetaDahsnboardSeparaciones}>
            {/*   <CardHeader color="danger" stats icon>
              <CardIcon color="danger">
                <Icon>info_outline</Icon>
              </CardIcon>
              <p className={classes.cardCategory}>Fixed Issues</p>
              <h3 className={classes.cardTitle}>75</h3>
            </CardHeader> */}
            <CardHeader>
              <GridContainer>
                <GridItem xs={5} sm={5} md={5}>
                  <h3>Carlos Fernández</h3>
                </GridItem>
                <GridItem xs={7} sm={7} md={7}>
                  <div style={{ textAlign: 'right' }}>
                    <h3>01/12/2019 - 15:05</h3>
                  </div>
                </GridItem>
              </GridContainer>
            </CardHeader>
            <div className={classes.tarjetaDashBoard}>
              <GridContainer >
                <GridItem xs={10} sm={10} md={10}>
                  <p>Solicito el día jueves 11 de Mayo para poder ir a la operación de mi hija María. Me ausentaré todo el día.</p>
                  <br></br>
                  <br></br>
                </GridItem>
                <GridItem xs={2} sm={2} md={2}>
                  <div style={{ textAlign: 'center' }}>
                    <i className="material-icons" style={{ fontSize: '50px', color: 'red' }}>send</i>
                    <label style={{ color: 'red', verticalAlign: 'super' }}>Enviada</label>
                  </div>
                </GridItem>
              </GridContainer>
            </div>
          </Card>
        </GridItem>

        <GridItem xs={12} sm={12} md={12} >
          <Card className={classes.tarjetaDahsnboardSeparaciones}>
            <CardHeader>
              <GridContainer>
                <GridItem xs={5} sm={5} md={5}>
                  <h3>Carlos Fernández</h3>
                </GridItem>
                <GridItem xs={7} sm={7} md={7}>
                  <div style={{ textAlign: 'right' }}>
                    <h3>01/11/2019 - 15:05 </h3>
                  </div>
                </GridItem>
              </GridContainer>
            </CardHeader>
            <div className={classes.tarjetaDashBoard}>
              <GridContainer >
                <GridItem xs={10} sm={10} md={10}>
                  <p>Tengo el casco caducado, me caducó el mes pasado.</p>
                  <br></br>
                  <br></br>
                </GridItem>
                <GridItem xs={2} sm={2} md={2}>
                  <div style={{ textAlign: 'center' }}>
                    <i className="material-icons" style={{ fontSize: '50px', color: 'orange' }}>timer</i>
                    <label style={{ color: 'orange', verticalAlign: 'super' }}>Recibida</label>
                  </div>
                </GridItem>
              </GridContainer>
            </div>

            {/*  <CardFooter stats>
              <div className={classes.stats}>
                <LocalOffer />
                Tracked from Github
              </div>
            </CardFooter> */}
          </Card>
        </GridItem>

        <GridItem xs={12} sm={12} md={12} >
          <Card className={classes.tarjetaDahsnboardSeparaciones}>
            {/*   <CardHeader color="danger" stats icon>
              <CardIcon color="danger">
                <Icon>info_outline</Icon>
              </CardIcon>
              <p className={classes.cardCategory}>Fixed Issues</p>
              <h3 className={classes.cardTitle}>75</h3>
            </CardHeader> */}
            <CardHeader>
              <GridContainer>
                <GridItem xs={5} sm={5} md={5}>
                  <h3>Carlos Fernández</h3>
                </GridItem>
                <GridItem xs={7} sm={7} md={7}>
                  <div style={{ textAlign: 'right' }}>
                    <h3>25/09/2019 - 15:05 </h3>
                  </div>
                </GridItem>
              </GridContainer>
            </CardHeader>
            <div className={classes.tarjetaDashBoard}>
              <GridContainer >
                <GridItem xs={10} sm={10} md={10}>
                  <p>Necesito coger el viernes 5 como día de vacaciones</p>
                  <p style={{ color: 'green', fontWeight: 'bold' }}>>> Sin problema</p>
                  <br></br>
                  <br></br>
                </GridItem>
                <GridItem xs={2} sm={2} md={2}>
                  <div style={{ textAlign: 'center' }}>
                    <i className="material-icons" style={{ fontSize: '50px', color: 'green' }}>done_all</i>
                    <label style={{ color: 'green', verticalAlign: 'super' }}>Resuelta</label>
                  </div>
                </GridItem>
              </GridContainer>
            </div>

            {/*  <CardFooter stats>
              <div className={classes.stats}>
                <LocalOffer />
                Tracked from Github
              </div>
            </CardFooter> */}
          </Card>
        </GridItem>

      


        {/*  <GridItem xs={12} sm={12} md={12}>
          <Card>
            <CardHeader color="danger" stats icon>
              <CardIcon color="danger">
                <Icon>info_outline</Icon>
              </CardIcon>
              <p className={classes.cardCategory}>Tarea 1</p>
              <h3 className={classes.cardTitle}>Sin asignar</h3>
            </CardHeader>
            <CardFooter stats>
              <div className={classes.stats}>
                <LocalOffer />
                Tracked from Github
              </div>
            </CardFooter>
          </Card>
        </GridItem>
        <GridItem xs={12} sm={12} md={12}>
          <Card>
            <CardHeader color="danger" stats icon>
              <CardIcon color="danger">
                <Icon>info_outline</Icon>
              </CardIcon>
              <p className={classes.cardCategory}>Fixed Issues</p>
              <h3 className={classes.cardTitle}>75</h3>
            </CardHeader>
            <CardFooter stats>
              <div className={classes.stats}>
                <LocalOffer />
                Tracked from Github
              </div>
            </CardFooter>
          </Card>
        </GridItem>
        <GridItem xs={12} sm={12} md={12}>
          <Card>
            <CardHeader color="danger" stats icon>
              <CardIcon color="danger">
                <Icon>info_outline</Icon>
              </CardIcon>
              <p className={classes.cardCategory}>Fixed Issues</p>
              <h3 className={classes.cardTitle}>75</h3>
            </CardHeader>
            <CardFooter stats>
              <div className={classes.stats}>
                <LocalOffer />
                Tracked from Github
              </div>
            </CardFooter>
          </Card>
        </GridItem>
       */}
       </GridContainer>
         <GridContainer>
           
          <GridItem xs={12} sm={12} md={12}>
            <div style={{ textAlign: 'right'}}>
            <br/>
            <br/>
            <br/>
              <label style={{fontSize: '30px', color: 'green'}}>Enviar Incidencia  </label>
              <i className="material-icons" style={{ fontSize: '50px', color: 'green', verticalAlign: 'top' }}>send</i>
            </div>
          </GridItem>
        </GridContainer>
      {/*     <GridContainer>
        <GridItem xs={12} sm={12} md={12}>
          <CustomTabs
            title="Tasks:"
            headerColor="primary"
            tabs={[
              {
                tabName: "Bugs",
                tabIcon: BugReport,
                tabContent: (
                  <Tasks
                    checkedIndexes={[0, 3]}
                    tasksIndexes={[0, 1, 2, 3]}
                    tasks={bugs}
                  />
                )
              },
              {
                tabName: "Website",
                tabIcon: Code,
                tabContent: (
                  <Tasks
                    checkedIndexes={[0]}
                    tasksIndexes={[0, 1]}
                    tasks={website}
                  />
                )
              },
              {
                tabName: "Server",
                tabIcon: Cloud,
                tabContent: (
                  <Tasks
                    checkedIndexes={[1]}
                    tasksIndexes={[0, 1, 2]}
                    tasks={server}
                  />
                )
              }
            ]}
          />
        </GridItem>
      </GridContainer>
 */}{/*       <GridContainer>
        <GridItem xs={12} sm={12} md={12}>
          <Card>
            <CardHeader color="warning">
              <h4 className={classes.cardTitleWhite}>Employees Stats</h4>
              <p className={classes.cardCategoryWhite}>
                New employees on 15th September, 2016
              </p>
            </CardHeader>
            <CardBody>
              <Table
                tableHeaderColor="warning"
                tableHead={["ID", "Name", "Salary", "Country"]}
                tableData={[
                  ["1", "Dakota Rice", "$36,738", "Niger"],
                  ["2", "Minerva Hooper", "$23,789", "Curaçao"],
                  ["3", "Sage Rodriguez", "$56,142", "Netherlands"],
                  ["4", "Philip Chaney", "$38,735", "Korea, South"]
                ]}
              />
            </CardBody>
          </Card>
        </GridItem>
      </GridContainer> */}
    </div>
  );
}
