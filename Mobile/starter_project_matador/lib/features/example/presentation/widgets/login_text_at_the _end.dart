import 'package:flutter/material.dart';

class TextAtTheEnd extends StatelessWidget {
  const TextAtTheEnd({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.only(
        top: (24 / 812) * MediaQuery.of(context).size.height,
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Text(
            'Have an account?  ',
            style: TextStyle(
              fontFamily: 'Urbanist',
              fontWeight: FontWeight.w500,
              fontSize: (14 / 812) * MediaQuery.of(context).size.height,
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
                fontSize: (14 / 812) * MediaQuery.of(context).size.height,
                color: Color(0xFF376AED),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
