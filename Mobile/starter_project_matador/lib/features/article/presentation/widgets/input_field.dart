import 'package:flutter/material.dart';

class InputField extends StatelessWidget {
  const InputField({Key? key, required this.labelText}) : super(key: key);
  final String labelText;

  @override
  Widget build(BuildContext context) {
    final Size screenSize = MediaQuery.of(context).size;

    return SizedBox(
      height: screenSize.height * 0.06,
      child: TextField(
        decoration: InputDecoration(
          hintText: labelText,
        ),
      ),
    );
  }
}