import 'package:flutter/material.dart';
import 'package:dartsmiths/core/utils/article_page_styles.dart';

import '../../../../core/utils/colors.dart';

Widget buildChip(String label, Function removeChips) {
  return InputChip(
    labelPadding: const EdgeInsets.all(2.0),
    label: Text(
      label,
      style: const TextStyle(
        color: darkPrimaryColorGradient,
      ),
    ),

    deleteIcon: const Icon(Icons.cancel_outlined),
    deleteIconColor: darkPrimaryColorGradient,
    onDeleted: () => {removeChips(label)},
    backgroundColor: whiteColor,
    padding: const EdgeInsets.all(8.0),
  );
}
