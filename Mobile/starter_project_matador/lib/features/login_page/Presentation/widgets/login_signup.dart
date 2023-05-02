import 'package:flutter/material.dart';

import '../../../../core/utils/constants/global_variables.dart';

class LoginSignupNavBar extends StatelessWidget {
  final double width;
  final double height;

  const LoginSignupNavBar({Key? key, required this.width, required this.height})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        Container(
          padding: EdgeInsets.only(top: 0.02 * height),
          alignment: Alignment.topCenter,
          // width: MediaQuery.of(context).size.width,
          height: height * 0.12,
          decoration: BoxDecoration(
            borderRadius: BorderRadiusDirectional.circular(30),
            color: Colors.blue,
          ),
          child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                const Text(
                  'LOGIN',
                  style: TextStyle(
                      fontSize: 20,
                      fontFamily: 'Urbanist',
                      color: Colors.white,
                      fontWeight: FontWeight.bold),
                ),
                SizedBox(
                  width: width * 0.25,
                ),
                const Text(
                  'SIGN UP',
                  style: TextStyle(
                      fontSize: 20,
                      color: unselectedColor,
                      fontWeight: FontWeight.bold),
                )
              ],
            ),
          ),
        ),
        Positioned(
          top: height * 0.075,
          child: Container(
            width: width,
            height: height * 0.05,
            decoration: BoxDecoration(
              borderRadius: BorderRadiusDirectional.circular(30),
              color: Colors.white,
            ),
          ),
        )
      ],
    );
  }
}
