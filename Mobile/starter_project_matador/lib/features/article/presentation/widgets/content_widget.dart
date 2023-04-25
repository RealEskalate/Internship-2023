import 'package:flutter/material.dart';

class ContentFormField extends StatelessWidget {
  const ContentFormField({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final Size screenSize = MediaQuery.of(context).size;

    return Expanded(
      child: Padding(
        padding: EdgeInsets.symmetric(vertical: screenSize.height * 0.02),
        child: Container(
          decoration: BoxDecoration(
            color: Colors.grey[200],
            borderRadius: BorderRadius.circular(10),
          ),
          padding: EdgeInsets.all(screenSize.height * 0.02),
          child: const TextField(
            decoration: InputDecoration.collapsed(
              hintText: 'Add Content',
            ),
            expands: true,
            minLines: null,
            maxLines: null,
          ),
        ),
      ),
    );
  }
}
