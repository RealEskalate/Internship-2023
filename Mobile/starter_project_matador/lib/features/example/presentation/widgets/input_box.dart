import 'package:flutter/material.dart';

class LabelledTextField extends StatelessWidget {
  final String hintText;
  final bool obscureText;
  LabelledTextField({required this.hintText, required this.obscureText});

  @override
  Widget build(BuildContext context) {
    return Container(
      // margin: EdgeInsets.only(top: 24),
      child: TextFormField(
        obscureText: obscureText,
        decoration: InputDecoration(
          hintText: hintText,
          hintStyle: TextStyle(
            fontFamily: 'Urbanist',
            fontStyle: FontStyle.italic,
            fontWeight: FontWeight.w100,
            fontSize: (14 / 812) * MediaQuery.of(context).size.height,
            color: Color(0xFF2D4379),
          ),
        ),
      ),
    );
  }
}
