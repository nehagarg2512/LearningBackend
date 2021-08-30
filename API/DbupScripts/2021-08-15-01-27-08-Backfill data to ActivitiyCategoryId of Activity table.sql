update a set ActivityCategoryId = ac.Id
from Activities a
Join ActivityCategory ac on a.Category = ac.Name