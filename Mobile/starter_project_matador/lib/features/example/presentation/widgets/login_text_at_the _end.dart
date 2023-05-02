import 'package:flutter/material.dart';

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
            style: TextStyle(
              fontFamily: 'Urbanist',
              fontWeight: FontWeight.w500,
              fontSize: (14 / 812) * Height,
              color: Color(0xFF2D4379),
            ),
          ),
          GestureDetector(
            onTap: () {},
            child: Text(
              'Login',
              style: TextStyle(
                fontFamily: 'Urbanist',
                fontWeight: FontWeight.w700,
                fontSize: (14 / 812) * Height,
                color: Color(0xFF376AED),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
