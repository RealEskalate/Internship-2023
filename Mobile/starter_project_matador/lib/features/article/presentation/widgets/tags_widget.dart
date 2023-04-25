import 'package:flutter/material.dart';

class TagsWidget extends StatelessWidget {
  const TagsWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final Size screenSize = MediaQuery.of(context).size;

    return Row(
      children: [
        Expanded(
          child: SizedBox(
            height: screenSize.height * 0.06,
            child: const TextField(
              decoration: InputDecoration(
                labelText: 'Add Tags',
              ),
            ),
          ),
        ),
        IconButton(
          onPressed: () {},
          icon: const Icon(Icons.add),
        ),
      ],
    );
  }
}
