import 'package:flutter/material.dart';

class TitleWidget extends StatelessWidget {
  const TitleWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final Size screenSize = MediaQuery.of(context).size;

    return SizedBox(
      height: screenSize.height * 0.06,
      child: const TextField(
        decoration: InputDecoration(
          labelText: 'Add Title',
        ),
      ),
    );
  }
}
