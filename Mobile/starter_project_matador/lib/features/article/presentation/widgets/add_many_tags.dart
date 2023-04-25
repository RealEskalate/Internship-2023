import 'package:flutter/material.dart';

class AddManyTags extends StatelessWidget {
  const AddManyTags({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final Size screenSize = MediaQuery.of(context).size;

    return Text(
              'Add as many tags as you want',
              textAlign: TextAlign.start,
              style: TextStyle(fontSize: screenSize.height * 0.02),
            );
  }
}
