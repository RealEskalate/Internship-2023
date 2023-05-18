import 'package:flutter/material.dart';
import 'package:matador/core/utils/constants/styles.dart';

class Footer extends StatelessWidget {
  const Footer({super.key});

  @override
  Widget build(BuildContext context) {
    var Height = MediaQuery.of(context).size.height;
    var Width = MediaQuery.of(context).size.width;
    return Container(
      margin: EdgeInsets.only(
        top: (17 / 812) * Height,
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Text(
            'Have an account?  ',
            style: haveAnAccountTextStyle,
          ),
          GestureDetector(
            onTap: () {},
            child: Text(
              'Login',
              style: loginBottomTextStyle,
            ),
          ),
        ],
      ),
    );
  }
}
