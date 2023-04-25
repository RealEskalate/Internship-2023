import 'package:flutter/material.dart';

class SubtitleWidget extends StatelessWidget {
  const SubtitleWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final Size screenSize = MediaQuery.of(context).size;

    return SizedBox(
      height: screenSize.height * 0.06,
      child: const TextField(
        decoration: InputDecoration(
          labelText: 'Add Subtitle',
        ),
      ),
    );
  }
}
