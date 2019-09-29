import React from "react";
// react plugin for creating charts
import ChartistGraph from "react-chartist";
// @material-ui/core
import { makeStyles } from "@material-ui/core/styles";
import Icon from "@material-ui/core/Icon";
// @material-ui/icons
import Store from "@material-ui/icons/Store";
import Warning from "@material-ui/icons/Warning";
import DateRange from "@material-ui/icons/DateRange";
import LocalOffer from "@material-ui/icons/LocalOffer";
import Update from "@material-ui/icons/Update";
import ArrowUpward from "@material-ui/icons/ArrowUpward";
import AccessTime from "@material-ui/icons/AccessTime";
import Accessibility from "@material-ui/icons/Accessibility";
import BugReport from "@material-ui/icons/BugReport";
import Code from "@material-ui/icons/Code";
import Cloud from "@material-ui/icons/Cloud";
// core components
import GridItem from "components/Grid/GridItem.js";
import GridContainer from "components/Grid/GridContainer.js";
import Table from "components/Table/Table.js";
import Tasks from "components/Tasks/Tasks.js";
import CustomTabs from "components/CustomTabs/CustomTabs.js";
import Danger from "components/Typography/Danger.js";
import Card from "components/Card/Card.js";
import CardHeader from "components/Card/CardHeader.js";
import CardIcon from "components/Card/CardIcon.js";
import CardBody from "components/Card/CardBody.js";
import CardFooter from "components/Card/CardFooter.js";

import { bugs, website, server } from "variables/general.js";

import {
  dailySalesChart,
  emailsSubscriptionChart,
  completedTasksChart
} from "variables/charts.js";

import styles from "assets/jss/material-dashboard-react/views/dashboardStyle.js";

const useStyles = makeStyles(styles);

export default function Dashboard() {
  const classes = useStyles();
  return (
    <div>
      <GridContainer >

        <GridItem>
          <h3>Mensajes sin validar</h3>
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
              <h3>01/12/2019 - 15:05 (Administración)</h3>
            </CardHeader>
            <div className={classes.tarjetaDashBoard}>
              <GridContainer >
                <GridItem xs={10} sm={10} md={10}>
                  <p>Reconocimiento médico el próximo 10 de julio, a las 18:00 en el Centro Médico.</p>
                  <p> Se ruega entregar firmado, el consentimiento que se adjunta, en secretaría. Muchas Gracias!</p>
                </GridItem>
                <GridItem xs={2} sm={2} md={2}>
                  <div style={{ textAlign: 'center' }}>
                    <i className="material-icons" style={{ fontSize: '50px' }}>crop_square</i>
                  </div>
                </GridItem>
                <GridItem xs={12} sm={12} md={12}>
                  <i className={"material-icons"} style={{ fontSize: "40px" }}>insert_drive_file</i>
                  <label style={{color:'black'}}>Consentimiento.pdf</label>
                 
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
              <h3>02/12/2019 - 16:26 (Administración)</h3>
            </CardHeader>
            <div className={classes.tarjetaDashBoard}>
              <GridContainer >
                <GridItem xs={10} sm={10} md={10} >
                  <p>Recordar inscribiros para asistir a la cena de Navidad de este año que se celebrará el Viernes 12 de Diciembre en Casa Pepe.</p>
                  <p>
                    Para isncribirse enviar un correo a 
                    <a href="RRHH@delfintubes.com"> RRHH@delfintubes.com</a>
                </p>
                </GridItem>
                <GridItem xs={2} sm={2} md={2} >
                  <div style={{ textAlign: 'center' }}>
                    <i className="material-icons" style={{ fontSize: '50px' }}>crop_square</i>
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
              <h3>03/12/2019 - 15:05 (Administración)</h3>
            </CardHeader>
            <div className={classes.tarjetaDashBoard}>
              <GridContainer >
                <GridItem xs={10} sm={10} md={10} >
                  <p>Reconocimiento médico el próximo 10 de julio, a las 18:00 en el Centro Médico.</p>
                  <p> Se ruega entregar firmado, el consentimiento que se adjunta, en secretaría. Muchas Gracias!</p>
                </GridItem>
                <GridItem xs={2} sm={2} md={2} >
                  <div style={{ textAlign: 'center' }}>
                    <i className="material-icons" style={{ fontSize: '50px' }}>crop_square</i>
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

        <GridItem>
          <br />
          <h3>Mensajes validados</h3>
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
              <h3>19/11/2019 - 15:05 (Administración)</h3>
            </CardHeader>
            <div className={classes.tarjetaDashBoard}>
              <GridContainer >
                <GridItem xs={10} sm={10} md={10} >
                  <p>Reconocimiento médico el próximo 10 de julio, a las 18:00 en el Centro Médico.</p>
                  <p> Se ruega entregar firmado, el consentimiento que se adjunta, en secretaría. Muchas Gracias!</p>
                </GridItem>
                <GridItem xs={2} sm={2} md={2} >
                  <div style={{ textAlign: 'center' }} className={classes.colorVerde}>
                    <i className="material-icons" style={{ fontSize: '50px' }}>check_box</i>
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
              <h3>18/11/2019 - 15:05 (Administración)</h3>
            </CardHeader>
            <div className={classes.tarjetaDashBoard}>
              <GridContainer >
                <GridItem xs={10} sm={10} md={10} >
                  <p>Reconocimiento médico el próximo 10 de julio, a las 18:00 en el Centro Médico.</p>
                  <p> Se ruega entregar firmado, el consentimiento que se adjunta, en secretaría. Muchas Gracias!</p>
                </GridItem>
                <GridItem xs={2} sm={2} md={2} >
                  <div style={{ textAlign: 'center' }} className={classes.colorVerde}>
                    <i className="material-icons" style={{ fontSize: '50px' }}>check_box</i>
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
              <h3>15/11/2019 - 15:05 (Administración)</h3>
            </CardHeader>
            <div className={classes.tarjetaDashBoard}>
              <GridContainer >
                <GridItem xs={10} sm={10} md={10} >
                  <p>Reconocimiento médico el próximo 10 de julio, a las 18:00 en el Centro Médico.</p>
                  <p> Se ruega entregar firmado, el consentimiento que se adjunta, en secretaría. Muchas Gracias!</p>
                </GridItem>
                <GridItem xs={2} sm={2} md={2} >
                  <div style={{ textAlign: 'center' }} className={classes.colorVerde}>
                    <i className="material-icons" style={{ fontSize: '50px' }}>check_box</i>
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
              <h3>13/11/2019 - 15:05 (Administración)</h3>
            </CardHeader>
            <div className={classes.tarjetaDashBoard}>
              <GridContainer >
                <GridItem xs={10} sm={10} md={10} >
                  <p>Reconocimiento médico el próximo 10 de julio, a las 18:00 en el Centro Médico.</p>
                  <p> Se ruega entregar firmado, el consentimiento que se adjunta, en secretaría. Muchas Gracias!</p>
                </GridItem>
                <GridItem xs={2} sm={2} md={2} >
                  <div style={{ textAlign: 'center' }} className={classes.colorVerde}>
                    <i className="material-icons" style={{ fontSize: '50px' }}>check_box</i>
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
              <h3>10/11/2019 - 15:05 (Administración)</h3>
            </CardHeader>
            <div className={classes.tarjetaDashBoard}>
              <GridContainer >
                <GridItem xs={10} sm={10} md={10} >
                  <p>Reconocimiento médico el próximo 10 de julio, a las 18:00 en el Centro Médico.</p>
                  <p> Se ruega entregar firmado, el consentimiento que se adjunta, en secretaría. Muchas Gracias!</p>
                </GridItem>
                <GridItem xs={2} sm={2} md={2} >
                  <div style={{ textAlign: 'center' }} className={classes.colorVerde}>
                    <i className="material-icons" style={{ fontSize: '50px' }}>check_box</i>
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
       */}</GridContainer>
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