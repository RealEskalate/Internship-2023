// Import flutter heplper library
import 'package:flutter/material.dart';
import 'logo.dart';
import 'signup_and_signin_box.dart';
import 'data_fill.dart';
import 'white_box.dart';

class SignUpPage extends StatelessWidget {
  const SignUpPage({super.key});

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
            child: Logo(),
            top: 65 / 812 * MediaQuery.of(context).size.height,
            left: 0,
            right: 0,
          ),
        ])));
  }
}
