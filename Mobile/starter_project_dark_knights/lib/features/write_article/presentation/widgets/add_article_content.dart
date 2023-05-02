import 'package:flutter/material.dart';
import '../../../../core/utils/colors.dart';

class AddArticleContent extends StatelessWidget {
  const AddArticleContent({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: const EdgeInsets.fromLTRB(33, 20, 33, 20),
      child: TextFormField(
        maxLines: 10,
        decoration: InputDecoration(
          border: OutlineInputBorder(
            borderRadius: BorderRadius.circular(15.0),
          ),
          hintText: 'Article Content',
          hintStyle: const TextStyle(
            fontFamily: 'Poppins',
            color: textFieldTextColor,
            fontSize: 13,
          ),
          floatingLabelBehavior: FloatingLabelBehavior.auto,
        ),
      ),
    );
  }
}
