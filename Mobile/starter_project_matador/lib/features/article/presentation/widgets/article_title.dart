import 'package:flutter/material.dart';

class ArticleTitle extends StatelessWidget {
  const ArticleTitle({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    final Size screenSize = MediaQuery.of(context).size;

    return const  Text(
          'New Article',
          style: TextStyle(color: Colors.black),
          textAlign: TextAlign.center,
        );
  }
}
