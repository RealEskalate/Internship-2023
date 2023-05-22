import 'package:flutter/material.dart';

import '../../../../core/utils/colors.dart';

class AddTitleAndSubtitle extends StatelessWidget {
  final TextEditingController titleController;
  final TextEditingController subTitleController;

  const AddTitleAndSubtitle(
      {super.key,
      required this.subTitleController,
      required this.titleController});

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Container(
          margin: const EdgeInsets.fromLTRB(33, 20, 33, 20),
          child: TextFormField(
            controller: titleController,
            decoration: const InputDecoration(
              border: UnderlineInputBorder(),
              labelText: 'Add title',
              labelStyle: TextStyle(
                fontFamily: 'Poppins',
                color: textFieldTextColor,
              ),
            ),
          ),
        ),
        Container(
          margin: const EdgeInsets.fromLTRB(33, 20, 33, 20),
          child: TextFormField(
            controller: subTitleController,
            decoration: const InputDecoration(
              border: UnderlineInputBorder(),
              labelText: 'Add subtitle',
              labelStyle: TextStyle(
                fontFamily: 'Poppins',
                color: textFieldTextColor,
                fontSize: 16,
              ),
            ),
          ),
        ),
      ],
    );
  }
}
