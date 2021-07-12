import React, { useEffect, useState } from 'react';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import Link from '@material-ui/core/Link';
import Grid from '@material-ui/core/Grid';
import Box from '@material-ui/core/Box';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import './Register.css';


const useStyles = makeStyles((theme) => ({
  paper: {
    marginTop: theme.spacing(8),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main,
  },
  form: {
    width: '100%', // Fix IE 11 issue.
    marginTop: theme.spacing(3),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
}));

export default function SignUp() {
  const classes = useStyles();
  const [password, setpassward] = useState()
  const [email, setemail] = useState()
  const [address, setAddress] = useState()
  const [phone, setPhone] = useState()
  const [firstName, setFirstName] = useState()
  const [lastName, setLastName] = useState()
  const [emailMessage, setemailMessage] = useState()
  const [PasswordMessage, setPasswordMessage] = useState()
  const [PhoneMessage, setPhoneMessage] = useState()
  const [user, setuser] = useState()

  const signup = () => {

    var raw = JSON.stringify({
      "employeeFirstName": firstName,
      "employeeLastName": lastName,
      "employeeAddress": address,
      "employeePhone": phone,
      "employeeEmail": email,
      "employeePassword": password
    });

    var requestOptions = {
      method: 'POST',
      body: raw,
      redirect: 'follow'
    };

    fetch("http://localhost:64551/api/Employee/Post", requestOptions)
      .then(response => response.text())
      .then(result => console.log(result))
      .catch(error => console.log('error', error));
  }

  const Validate = () => {
    let flage = true
    if (!/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(email)) {
      flage = false
      setemailMessage("email isn't valid")
    }
    if (password.length < 6) {
      setPasswordMessage("password isn't valid")
      flage = false
    }
    if (phone.length < 10) {
      setPhoneMessage("phone isn't valid")
      flage = false
    }
    if (flage == true)
      signup()
  }

  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      <div className={classes.paper}>
        <Avatar className={classes.avatar}>
          <LockOutlinedIcon />
        </Avatar>
        <Typography component="h1" variant="h5">
          Sign up
        </Typography>
        <form className={classes.form} noValidate>
          <Grid container spacing={2}>
            <Grid item xs={12} sm={6}>
              <TextField
                autoComplete="fname"
                name="firstName"
                variant="outlined"
                required
                fullWidth
                id="firstName"
                label="First Name"
                autoFocus
                onChange={(e) => setFirstName(e.target.value)}
              />
            </Grid>
            <Grid item xs={12} sm={6}>
              <TextField
                variant="outlined"
                required
                fullWidth
                id="lastName"
                label="Last Name"
                name="lastName"
                autoComplete="lname"
                onChange={(e) => setLastName(e.target.value)}
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                variant="outlined"
                required
                fullWidth
                id="adress"
                label="Address"
                name="adress"
                autoComplete="adress"
                onChange={(e) => setAddress(e.target.value)}
              />
            </Grid>
          
            <Grid item xs={12}>
              <TextField
                variant="outlined"
                required
                fullWidth
                id="phone"
                label="Phone"
                name="phone"
                autoComplete="phone"
                onChange={(e) => setPhone(e.target.value)}
              />
                <p style={{color:"red"}}>{PhoneMessage}</p>
            </Grid>
          
            <Grid item xs={12}>
              <TextField
                variant="outlined"
                required
                fullWidth
                id="email"
                label="Email Address"
                name="email"
                autoComplete="email"

                onChange={(e) => setemail(e.target.value)}
              />
            </Grid>
            <p style={{color:"red"}}>{emailMessage}</p>
           
            <Grid item xs={12}>
              <TextField
                variant="outlined"
                required
                fullWidth
                name="password"
                label="Password"
                type="password"
                id="password"
                autoComplete="current-password"
                onChange={(e) => setpassward(e.target.value)}
              />
            </Grid>
            <p style={{color:"red"}}>{PasswordMessage}</p>
          </Grid>
          <Button
            fullWidth
            variant="contained"
            color="primary"
            className={classes.submit}
            onClick={() => Validate()}
          >
            Sign Up
          </Button>
          <Grid container justify="flex-end">
            <Grid item>
              <Link href="#" variant="body2">
                Already have an account? Sign in
              </Link>
            </Grid>
          </Grid>
        </form>
      </div>

    </Container>
  );
}