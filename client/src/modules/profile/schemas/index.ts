import { z } from "zod";

const MAX_UPLOAD_SIZE = 1024 * 1024 * 5; // 5MB
const FILE_TYPES = ['image/png', 'image/jpg', 'image/svg'];

export const profileSchema = z.object({
    image: z.instanceof(File || null).optional()
    .refine((file) => {
        return !file || file.size <= MAX_UPLOAD_SIZE;
    }, 'File size must be less than 5MB')
    .refine((file) => {
        return FILE_TYPES.includes(file?.type as string);
    }, 'File must be of type png, jpg or svg'),
    firstName: z.string().optional(),
    lastName: z.string().optional(),
    email: z.string().email().optional(),
});
