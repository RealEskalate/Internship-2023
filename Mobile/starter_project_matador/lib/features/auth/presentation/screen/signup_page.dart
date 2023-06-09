// Import flutter heplper library
import 'package:flutter/material.dart';
import '../../../../core/utils/constants/colors.dart';
import '../../../../core/utils/constants/styles.dart';
import '../widgets/signup/data_fill.dart';
import '../widgets/signup/signup_and_signin_box.dart';
import '../widgets/signup/signup_logo.dart';

class SignUpPage extends StatelessWidget {
  const SignUpPage({super.key});

  @override
  Widget build(BuildContext context) {
    var Height = MediaQuery.of(context).size.height;
    var Width = MediaQuery.of(context).size.width;
    return Scaffold(
        backgroundColor: profileAvatarCircularRingColor,
        body: SafeArea(
            child: Stack(children: <Widget>[
          Positioned(
            child: SigninSignupBox(),
            top: 173 / 812 * Height,
            left: 0,
            right: 0,
          ),
          Positioned(
            child: DataFillBox(),
            top: 237 / 812 * Height,
            left: 0,
            right: 0,
          ),
          Positioned(
            child: Logo(),
            top: 65 / 812 * Height,
            left: 0,
            right: 0,
          ),
        ])));
  }
}
