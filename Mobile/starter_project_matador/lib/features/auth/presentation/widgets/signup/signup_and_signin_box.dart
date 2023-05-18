import 'package:flutter/material.dart';
import 'package:matador/core/utils/constants/colors.dart';
import 'package:matador/core/utils/constants/styles.dart';

class SigninSignupBox extends StatelessWidget {
  const SigninSignupBox({super.key});

  @override
  Widget build(BuildContext context) {
    var Height = MediaQuery.of(context).size.height;
    var Width = MediaQuery.of(context).size.width;
    return Container(
      height: 96 / 812 * Height,
      width: Width,
      decoration: BoxDecoration(
        color: primaryColor,
        borderRadius: BorderRadius.only(
          topLeft: Radius.circular(28 / 812 * Height),
          topRight: Radius.circular(28 / 812 * Height),
        ),
        boxShadow: [
          BoxShadow(
            color: borderShadow,
            blurRadius: (22 / 812) * Height,
            offset: Offset(0, 4),
          ),
        ],
      ),
      child: Align(
        alignment: Alignment.topCenter,
        child: Padding(
          padding: EdgeInsets.only(
            top: (20.0 / 812) * Height,
          ),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: <Widget>[
              Text(
                'LOGIN',
                style: loginUpTextStyle,
              ),
              Text(
                'SIGNUP',
                style: signupUpTextStyle,
              ),
            ],
          ),
        ),
      ),
    );
  }
}
