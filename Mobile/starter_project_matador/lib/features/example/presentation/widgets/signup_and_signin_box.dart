import 'package:flutter/material.dart';

class SigninSignupBox extends StatelessWidget {
  const SigninSignupBox({super.key});

  @override
  Widget build(BuildContext context) {
    var row = Align(
      alignment: Alignment.topCenter,
      child: Padding(
        padding: EdgeInsets.only(
          top: (20.0 / 812) * MediaQuery.of(context).size.height,
        ),
        child: Row(
          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
          children: <Widget>[
            Text(
              'LOGIN',
              style: TextStyle(
                fontFamily: 'Urbanist',
                fontWeight: FontWeight.bold,
                fontSize: (18 / 812) * MediaQuery.of(context).size.height,
                letterSpacing: 1,
                color: Colors.white.withOpacity(0.25),
              ),
            ),
            Text(
              'SIGNUP',
              style: TextStyle(
                fontFamily: 'Urbanist',
                fontWeight: FontWeight.bold,
                fontSize: (18 / 812) * MediaQuery.of(context).size.height,
                letterSpacing: 1,
                color: Colors.white,
              ),
            ),
          ],
        ),
      ),
    );
    return Container(
      height: 96 / 812 * MediaQuery.of(context).size.height,
      width: double.infinity,
      decoration: BoxDecoration(
        color: Color(0xff376AED),
        borderRadius: BorderRadius.only(
          topLeft:
              Radius.circular(28 / 812 * MediaQuery.of(context).size.height),
          topRight:
              Radius.circular(28 / 812 * MediaQuery.of(context).size.height),
        ),
        boxShadow: [
          BoxShadow(
            color: Color.fromRGBO(79, 91, 121, 0.1),
            blurRadius: (22 / 812) * MediaQuery.of(context).size.height,
            offset: Offset(0, 4),
          ),
        ],
      ),
      child: row,
    );
  }
}
