import 'package:flutter/material.dart';

class LabelledTextField extends StatelessWidget {
  final String hintText;
  final bool obscureText;
  LabelledTextField({required this.hintText, required this.obscureText});

  @override
  Widget build(BuildContext context) {
    var Height = MediaQuery.of(context).size.height;
    var Width = MediaQuery.of(context).size.width;
    return Container(
      // margin: EdgeInsets.only(top: 24),
      child: TextFormField(
        obscureText: obscureText,
        decoration: InputDecoration(
          hintText: hintText,
          hintStyle: TextStyle(
            fontFamily: 'Urbanist',
            fontStyle: FontStyle.italic,
            fontWeight: FontWeight.bold,
            fontSize: (14 / 812) * Height,
            color: Color(0xFF2D4379),
          ),
        ),
      ),
    );
  }
}
