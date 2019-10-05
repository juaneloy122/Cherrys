import {
  container,
  defaultFont,
  primaryColor,
  defaultBoxShadow,
  infoColor,
  successColor,
  warningColor,
  dangerColor,
  whiteColor,
  grayColor
} from "assets/jss/material-dashboard-react.js";

const headerStyle = () => ({
  appBar: {
    backgroundColor: "#FFF",
    boxShadow: "none",
    borderBottom: "0",
    marginBottom: "0",
    position: "absolute",
    width: "100%",
    zIndex: "1029",
    color: grayColor[7],
    border: "0",
    borderRadius: "3px",
    transition: "all 150ms ease 0s",
    minHeight: "50px",
    display: "block"
  },
  container: {
    ...container,
    minHeight: "50px"
  },
  flex: {
    flex: 1
  },
  title: {
    ...defaultFont,
    letterSpacing: "unset",
    lineHeight: "30px",
    fontSize: "30px",
    borderRadius: "3px",
    textTransform: "none",
    color: "#00acc1",
    padding:"0!Important",
    paddingTop:"50px!Important",
    paddingLeft:"0px!Important",
    "&:hover,&:focus": {
      background: "#FFF"
    }
  },

  margenDerecho:{
    marginLeft: "90%",
    marginBottom:"10px",
    marginTop: "1%"
  },

  appResponsive: {
    top: "8px"
  },

  margenSuperior: {
    paddingTop: "20px!Important"
  },
  
  primary: {
    backgroundColor:  "#FFF",
    color: whiteColor,
    ...defaultBoxShadow
  },
  info: {
    backgroundColor:  "#FFF",
    color: whiteColor,
    ...defaultBoxShadow
  },
  success: {
    backgroundColor:  "#FFF",
    color: whiteColor,
    ...defaultBoxShadow
  },
  warning: {
    backgroundColor:  "#FFF",
    color: whiteColor,
    ...defaultBoxShadow
  },
  danger: {
    backgroundColor: "#FFF",
    color: whiteColor,
    ...defaultBoxShadow
  },
 

});

export default headerStyle;
