// Import flutter heplper library
import 'package:flutter/material.dart';
import '../widgets/logo.dart';
import '../widgets/signup_and_signin_box.dart';
import '../widgets/data_fill.dart';
import '../widgets/white_box.dart';

class SignupPage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Sign Up Page',
      home: Scaff(),
    );
  }
}

class Scaff extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        backgroundColor: Colors.white,
        body: SafeArea(
            child: Stack(children: <Widget>[
          Positioned(
            child: DataFillBox(),
            top: 237 / 812 * MediaQuery.of(context).size.height,
            left: 0,
            right: 0,
          ),
          Positioned(
            child: SigninSignupBox(),
            top: 173 / 812 * MediaQuery.of(context).size.height,
            left: 0,
            right: 0,
          ),
          Positioned(
            child: Box(),
            top: 246 / 812 * MediaQuery.of(context).size.height,
            left: 0,
            right: 0,
          ),
          Positioned(
            child: DataFillBox(),
            top: 237 / 812 * MediaQuery.of(context).size.height,
            left: 0,
            right: 0,
          ),
          Positioned(
            child: const Logo(),
            top: 65 / 812 * MediaQuery.of(context).size.height,
            left: 0,
            right: 0,
          ),
        ])));
  }
}
