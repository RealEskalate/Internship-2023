import 'package:flutter/material.dart';
import 'package:matador/core/utils/constants/styles.dart';

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
          hintStyle: hintTextStyle,
        ),
      ),
    );
  }
}
